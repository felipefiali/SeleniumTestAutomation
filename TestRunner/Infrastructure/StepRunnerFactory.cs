namespace TestRunner.Infrastructure
{
    using System;
    using Driver;
    using TestStructure;

    public class StepRunnerFactory
    {
        public static StepRunner Construct(Step step, Driver driver)
        {
            if (step is AssertValue)
            {
                return new AssertValueRunner(step as AssertValue, driver);
            }
            else if (step is Click)
            {
                return new ClickRunner(step as Click, driver);
            }
            else if (step is ClickIfFound)
            {
                return new ClickIfFoundRunner(step as ClickIfFound, driver);
            }
            else if (step is Navigate)
            {
                return new NavigateRunner(step as Navigate, driver);
            }
            else if (step is SelectDropDownItem)
            {
                return new SelectDropDownItemRunner(step as SelectDropDownItem, driver);
            }
            else if (step is TypeText)
            {
                return new TypeTextRunner(step as TypeText, driver);
            }
            else if (step is Wait)
            {
                return new WaitRunner(step as Wait, driver);
            }
            else if (step is SwitchToiFrame)
            {
                return new SwitchToiFrameRunner(step as SwitchToiFrame, driver);
            }
            else if (step is AssertElementNotPresent)
            {
                return new AssertElementNotPresentRunner(step as AssertElementNotPresent, driver);
            }
            else if (step is SetCheckbox)
            {
                return new SetCheckboxRunner(step as SetCheckbox, driver);
            }
            else if (step is CompareImage)
            {
                return new CompareImageRunner(step as CompareImage, driver);
            }
            else if (step is SendKeysAndEnter)
            {
                return new SendKeysAndEnterRunner(step as SendKeysAndEnter, driver);
            }
            else if (step is AssertAttributeValue)
            {
                return new AssertAttributeValueRunner(step as AssertAttributeValue, driver);
            }
            else
            {
                throw new Exception(string.Format("Could not create a runner for step of type {0}", step.GetType().Name));
            }
        }
    }
}