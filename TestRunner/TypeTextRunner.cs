namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class TypeTextRunner : StepRunner
    {
        private TypeText TypeTextStep { get; set; }

        public TypeTextRunner(TypeText step, Driver driver)
            : base(step, driver)
        {
            TypeTextStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                Driver.TypeText(TypeTextStep.ElementCssPath, TypeTextStep.ElementHint, TypeTextStep.Text);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }
    }
}