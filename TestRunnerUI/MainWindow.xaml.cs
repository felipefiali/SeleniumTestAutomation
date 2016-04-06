namespace TestRunnerUI
{
    using System;
    using System.IO;
    using System.Windows;
    using Gat.Controls;
    using TestRunner;
    using TestRunner.Infrastructure;
    using TestStructure;
    using WindowMessage = System.Windows.MessageBox;

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnBrowser_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenDialogView();

            var dialogViewModel = (OpenDialogViewModel)dialog.DataContext;
            dialogViewModel.AddFileFilterExtension(Constants.XmlFileExtension);
            dialogViewModel.SelectedFileFilterExtension = Constants.XmlFileExtension;
            dialogViewModel.IsDirectoryChooser = false;
            dialogViewModel.IsSaveDialog = false;            

            bool? result = dialogViewModel.Show();

            if (result == true)
            {
                txtFilePath.Text = dialogViewModel.SelectedFilePath;
            }
        }

        private void btnRun_Click(object sender, RoutedEventArgs e)
        {
            var filePath = txtFilePath.Text;
            Test test = null;
            ITestResult testResult = null;

            try
            {
                if (!File.Exists(filePath))
                {
                    ReportErrorAsMessageBox("The specified file does not exist.", "An error has occurred");

                    return;
                }
                else
                {
                    test = TestDeserializer.DeserializeTest(filePath);
                }

                using (var testRunner = new TestRunner(test))
                {
                    testResult = testRunner.RunTest();
                }
                    if (!testResult.IsSuccessful())
                    {
                        var testFailureException = new TestFailureException(filePath, testResult.GetFailedSteps());

                        ReportErrorOnErrorWindow(testFailureException.Message);
                    }
                    else
                    {
                        ReportSucess();
                    }
                
            }
            catch (Exception ex)
            {
                ReportErrorAsMessageBox(ex.Message, "An error has occurred");
            }
        }

        private void ReportErrorAsMessageBox(string error, string caption)
        {
            WindowMessage.Show(error, caption, MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void ReportErrorOnErrorWindow(string exceptionMessage)
        {
            var errorWindow = new ErrorWindow();

            errorWindow.SetExceptionText(exceptionMessage);

            errorWindow.ShowDialog();
        }

        private void ReportSucess()
        {
            WindowMessage.Show("Test completed successfully.", "Test result", MessageBoxButton.OK, MessageBoxImage.Information);
        }

    }
}