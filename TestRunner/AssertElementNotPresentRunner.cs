namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class AssertElementNotPresentRunner : StepRunner
    {
        private AssertElementNotPresent AssertElementNotPresentStep { get; set; }

        public AssertElementNotPresentRunner(AssertElementNotPresent step, Driver driver)
            : base(step, driver)
        {
            AssertElementNotPresentStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                if (Driver.CanFindElement(AssertElementNotPresentStep.ElementCssPath, AssertElementNotPresentStep.ElementHint))
                {
                    StepResult.Exception = HandleException(string.Format("The element ({0}) should not be present on the supplied CSS path ({1})", AssertElementNotPresentStep.ElementHint, AssertElementNotPresentStep.ElementCssPath), FailureType.ElementShouldNotBePresent); 
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