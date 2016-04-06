namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class SetCheckboxRunner : StepRunner
    {
        private SetCheckbox SetCheckboxStep { get; set; }

        public SetCheckboxRunner(SetCheckbox step)
            : base(step)
        {
            SetCheckboxStep = step;
        }

        public override IStepResult Run(Driver driver)
        {
            try
            {
                driver.SetCheckbox(SetCheckboxStep.ElementCssPath, SetCheckboxStep.ElementHint, SetCheckboxStep.Checked);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }
    }
}
