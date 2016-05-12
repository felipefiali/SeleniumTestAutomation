namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class AssertAttributeValueRunner : StepRunner
    {
        private AssertAttributeValue AssertAttributeValueStep { get; set; }

        public AssertAttributeValueRunner(AssertAttributeValue step, Driver driver)
            : base(step, driver)
        {
            AssertAttributeValueStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                var attributeValue = Driver.GetElementAttributeValue(AssertAttributeValueStep.ElementCssPath, AssertAttributeValueStep.ElementHint, AssertAttributeValueStep.AttributeName);

                if (!string.Equals(attributeValue, AssertAttributeValueStep.ExpectedValue))
                {
                    StepResult.Exception = HandleAssertionException(AssertAttributeValueStep.ErrorMessage, AssertAttributeValueStep.ExpectedValue, attributeValue);
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
