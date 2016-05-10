namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class ClickRunner : StepRunner
    {
        private Click ClickStep { get; set; }

        public ClickRunner(Click step, Driver driver)
            : base(step, driver)
        {
            ClickStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                Driver.Click(ClickStep.LinkCssPath, ClickStep.ElementHint);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }
    }
}