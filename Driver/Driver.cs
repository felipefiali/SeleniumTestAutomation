namespace Driver
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Chrome;
    using OpenQA.Selenium.Support.UI;

    public class Driver : IDisposable
    {
        private IWebDriver ChromeDriver { get; set; }

        private string DriverPath
        {
            get
            {
#if DEBUG
    return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..\Driver\Drivers");
#else
    return "Drivers";
#endif
            }
        }

        public Driver()
        {
            ChromeDriver = new ChromeDriver(DriverPath);
            ChromeDriver.Manage().Window.Maximize();
        }        

        public void Navigate(string url)
        {
            ChromeDriver.Navigate().GoToUrl(url);
        }      

        public string GetValueInElement(string elementCssPath, string elementFriendlyName)
        {
            var element = FindElement(elementCssPath, elementFriendlyName);

            return element.Text;
        }

        public void Click(string elementCssPath, string elementFriendlyName)
        {
            var element = FindElement(elementCssPath, elementFriendlyName);

            ClickElement(element);
        }    
        
        public void ClickIfElementIsFound(string elementCssPath, string elementFriendlyName)
        {
            var element = TryFindElement(elementCssPath);

            if (element != null)
            {
                ClickElement(element);
            }
        }
        
        public void TypeText(string elementCssPath, string elementFriendlyName, string text)
        {
            var element = FindElement(elementCssPath, elementFriendlyName);

            // Only to trigger events on the element:
            element.SendKeys(Keys.NumberPad1);

            element.Clear();

            element.SendKeys(text);
        }

        public void SelectDropDownItem(string elementCssPath, string elementFriendlyName, string itemText)
        {
            var element = FindElement(elementCssPath, elementFriendlyName);

            new SelectElement(element).SelectByText(itemText);
        }

        public void SwitchToiFrame(string cssPath, string elementFriendlyName)
        {
            try
            {
                ChromeDriver.SwitchTo().Frame(FindElement(cssPath, elementFriendlyName));
            }
            catch (NoSuchElementException noSuchElementException)
            {
                ThrowElementNotFoundException(cssPath, elementFriendlyName, noSuchElementException);
            }
        }

        public void SwitchToDefaultContent()
        {
            ChromeDriver.SwitchTo().DefaultContent();
        }

        public bool CanFindElement(string cssPath, string elementFriendlyName)
        {
            IEnumerable<IWebElement> foundElements = null;

            try
            {
                var webDriverWait = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(3));

                foundElements = ChromeDriver.FindElements(By.CssSelector(cssPath));
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return foundElements.Count() > 0;
        }

        public void SetCheckbox(string cssPath, string elementFriendlyName, bool shouldBeChecked)
        {
            var checkBoxElement = FindElement(cssPath, elementFriendlyName);

            if (shouldBeChecked != checkBoxElement.Selected)
            {
                checkBoxElement.Click();
            }
        }

        public byte[] GetImageDataFromSrcAttribute(string elementCssPath, string elementFriendlyName)
        {
            var imageUrl = GetElementAttribute(elementCssPath, elementFriendlyName, HtmlConstants.SourceAttribute);

            return DownloadImageDataFromUrl(imageUrl);
        }

        private byte[] DownloadImageDataFromUrl(string imageUrl)
        {
            byte[] imageData = null;
            try
            {
                using (var webClient = new WebClient())
                {
                    imageData = webClient.DownloadData(imageUrl);
                }
            }
            catch (WebException ex)
            {
                throw new Exception(string.Format("Could not download the image on the URL supplied ({0}). Check if the URL is valid and the image is available.", imageUrl), ex);
            }

            return imageData;
        }

        private string GetElementAttribute(string elementCssPath, string elementFriendlyName, string attributeName)
        {
            return FindElement(elementCssPath, elementFriendlyName).GetAttribute(attributeName);
        }

        /// <summary>
        /// Tries to find the HTML element given its CSS path.
        /// </summary>
        /// <param name="cssPath">The CSS path of the HTML element to be found.</param>
        /// <param name="elementFriendlyName">The friendly name for the HTML element to be found.</param>
        /// <returns>An HTML element object.</returns>
        /// <exception cref="Exception">Thrown when no element is found on the supplied CSS path.</exception>
        private IWebElement FindElement(string cssPath, string elementFriendlyName)
        {
            IWebElement element = null;

            try
            {
                var webDriverWait = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(5));

                element = webDriverWait.Until(ChromeDriver => ChromeDriver.FindElement(By.CssSelector(cssPath)));                
            }            
            catch (NoSuchElementException noSuchElementException)
            {
                ThrowElementNotFoundException(cssPath, elementFriendlyName, noSuchElementException);                
            }
            catch (WebDriverTimeoutException webDriverTimeoutException)
            {
                ThrowElementNotFoundException(cssPath, elementFriendlyName, webDriverTimeoutException);                
            }

            return element;
        }

        /// <summary>
        /// Tries to find the HTML element given its CSS path.
        /// </summary>
        /// <param name="cssPath">The CSS path of the HTML element to be found.</param>        
        /// <returns>An HTML element object or null if none is found on the supplied CSS path.</returns>        
        private IWebElement TryFindElement(string cssPath)
        {
            IWebElement element = null;

            try
            {
                var webDriverWait = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(5));

                element = webDriverWait.Until(ChromeDriver => ChromeDriver.FindElement(By.CssSelector(cssPath)));
            }
            catch
            {
                element = null;
            }

            return element;
        }

        private void ClickElement(IWebElement element)
        {
            var webDriverWait = new WebDriverWait(ChromeDriver, TimeSpan.FromSeconds(5));

            webDriverWait.Until<bool>(driver => element.Enabled);

            element.Click();
        }

        private void ThrowElementNotFoundException(string cssPath, string elementFriendlyName, Exception exception)
        {
            throw new Exception(string.Format("Could not find the element ({0}) on the supplied CSS path ({1})", elementFriendlyName, cssPath), exception);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (ChromeDriver != null)
                    {
                        ChromeDriver.Close();

                        ChromeDriver.Dispose();
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {            
            Dispose(true);         
        }
        #endregion
    }
}