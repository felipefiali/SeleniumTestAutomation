namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class NavigateRunner : StepRunner
    {
        private Navigate NavigateStep { get; set; }

        public NavigateRunner(Navigate step)
            : base(step)
        {
            NavigateStep = step;
        }

        public override IStepResult Run(Driver driver)
        {
            try
            {
                driver.Navigate(NavigateStep.URL);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.Unknown);
            }

            return StepResult;
        }
    }
}