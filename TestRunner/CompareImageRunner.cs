namespace TestRunner
{
    using Common;
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class CompareImageRunner : StepRunner, IValidateStepExecution
    {
        private CompareImage CompareImageStep { get; set; }

        public CompareImageRunner(CompareImage step, Driver driver)
            : base(step, driver)
        {
            CompareImageStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                var imageData = Driver.GetImageDataFromSrcAttribute(CompareImageStep.ElementCssPath, CompareImageStep.ElementHint);

                var downloadedImageMd5Hash = Md5HashComputer.CreateMd5HashString(imageData);

                if (!string.Equals(CompareImageStep.ImageMd5Hash, downloadedImageMd5Hash))
                {
                    StepResult.Exception = HandleImageComparisonException(CompareImageStep.ImageMd5Hash, downloadedImageMd5Hash);
                }
            }            
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.Unknown);
            }

            return StepResult;
        }

        public bool ValidateExecution()
        {
            bool validationSuccess = true;

            try
            {
                if (!string.Equals(Driver.GetElementTagName(CompareImageStep.ElementCssPath, CompareImageStep.ElementHint), HtmlConstants.ImageTagName))
                {
                    var validationException = new Exception(string.Format("The {0} step can only be used to compare images in {1} HTML elements.", CompareImageStep.GetType().Name, HtmlConstants.ImageTagName));

                    StepResult.Exception = HandleException(validationException, FailureType.StepValidation);

                    validationSuccess = false;
                }
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.Unknown);
            }

            return validationSuccess;
        }
    }
}