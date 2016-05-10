namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class ClickIfFoundRunner : StepRunner
    {
        private ClickIfFound ClickIfFoundStep { get; set; }

        public ClickIfFoundRunner(ClickIfFound step, Driver driver)
            : base(step, driver)
        {
            ClickIfFoundStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                Driver.ClickIfElementIsFound(ClickIfFoundStep.LinkCssPath, ClickIfFoundStep.ElementHint);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }
    }
}