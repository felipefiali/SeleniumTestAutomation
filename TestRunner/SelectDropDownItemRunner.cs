namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class SelectDropDownItemRunner : StepRunner
    {
        private SelectDropDownItem SelectDropDownItemStep { get; set; }

        public SelectDropDownItemRunner(SelectDropDownItem step)
            : base(step)
        {
            SelectDropDownItemStep = step;
        }

        public override IStepResult Run(Driver driver)
        {
            try
            {
                driver.SelectDropDownItem(SelectDropDownItemStep.ElementCssPath, SelectDropDownItemStep.ElementHint, SelectDropDownItemStep.ItemText);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }
    }
}