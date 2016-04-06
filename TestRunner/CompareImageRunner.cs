namespace TestRunner
{
    using Common;
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class CompareImageRunner : StepRunner
    {
        private CompareImage CompareImageStep { get; set; }

        public CompareImageRunner(CompareImage step)
            : base(step)
        {
            CompareImageStep = step;
        }

        public override IStepResult Run(Driver driver)
        {
            try
            {
                var imageData = driver.GetImageDataFromSrcAttribute(CompareImageStep.ElementCssPath, CompareImageStep.ElementHint);

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
    }
}
