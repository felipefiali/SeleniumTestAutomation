namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class AssertValueRunner : StepRunner
    {
        private AssertValue AssertValueStep { get; set; }

        public AssertValueRunner(AssertValue step, Driver driver)
            : base(step, driver)
        {
            AssertValueStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                var elementValue = Driver.GetValueInElement(AssertValueStep.ElementCssPath, AssertValueStep.ElementHint);

                if (!string.Equals(elementValue, AssertValueStep.ExpectedValue))
                {
                    StepResult.Exception = HandleAssertionException(AssertValueStep.ErrorMessage, AssertValueStep.ExpectedValue, elementValue);
                }
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }
    }
}