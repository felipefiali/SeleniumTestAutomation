namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class NavigateRunner : StepRunner
    {
        private Navigate NavigateStep { get; set; }

        public NavigateRunner(Navigate step, Driver driver)
            : base(step, driver)
        {
            NavigateStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                Driver.Navigate(NavigateStep.URL);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.Unknown);
            }

            return StepResult;
        }
    }
}