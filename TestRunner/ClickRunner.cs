namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class ClickRunner : StepRunner
    {
        private Click ClickStep { get; set; }

        public ClickRunner(Click step)
            : base(step)
        {
            ClickStep = step;
        }

        public override IStepResult Run(Driver driver)
        {
            try
            {
                driver.Click(ClickStep.LinkCssPath, ClickStep.ElementHint);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }
    }
}