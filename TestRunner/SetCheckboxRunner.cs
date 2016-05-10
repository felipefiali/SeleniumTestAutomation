namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class SetCheckboxRunner : StepRunner
    {
        private SetCheckbox SetCheckboxStep { get; set; }

        public SetCheckboxRunner(SetCheckbox step, Driver driver)
            : base(step, driver)
        {
            SetCheckboxStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                Driver.SetCheckbox(SetCheckboxStep.ElementCssPath, SetCheckboxStep.ElementHint, SetCheckboxStep.Checked);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }
    }
}
