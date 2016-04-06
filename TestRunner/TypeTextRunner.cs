namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class TypeTextRunner : StepRunner
    {
        private TypeText TypeTextStep { get; set; }

        public TypeTextRunner(TypeText step)
            : base(step)
        {
            TypeTextStep = step;
        }

        public override IStepResult Run(Driver driver)
        {
            try
            {
                driver.TypeText(TypeTextStep.ElementCssPath, TypeTextStep.ElementHint, TypeTextStep.Text);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }
    }
}