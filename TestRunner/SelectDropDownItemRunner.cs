namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class SelectDropDownItemRunner : StepRunner
    {
        private SelectDropDownItem SelectDropDownItemStep { get; set; }

        public SelectDropDownItemRunner(SelectDropDownItem step, Driver driver)
            : base(step, driver)
        {
            SelectDropDownItemStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                Driver.SelectDropDownItem(SelectDropDownItemStep.ElementCssPath, SelectDropDownItemStep.ElementHint, SelectDropDownItemStep.ItemText);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }
    }
}