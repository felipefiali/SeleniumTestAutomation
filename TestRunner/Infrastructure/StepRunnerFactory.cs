namespace TestRunner.Infrastructure
{
    using System;
    using TestStructure;

    public class StepRunnerFactory
    {
        public static StepRunner Construct(Step step)
        {
            if (step is AssertValue)
            {
                return new AssertValueRunner(step as AssertValue);
            }
            else if (step is Click)
            {
                return new ClickRunner(step as Click);
            }
            else if (step is ClickIfFound)
            {
                return new ClickIfFoundRunner(step as ClickIfFound);                        
            }
            else if (step is Navigate)
            {
                return new NavigateRunner(step as Navigate);
            }
            else if (step is SelectDropDownItem)
            {
                return new SelectDropDownItemRunner(step as SelectDropDownItem);
            }
            else if (step is TypeText)
            {
                return new TypeTextRunner(step as TypeText);
            }
            else if (step is Wait)
            {
                return new WaitRunner(step as Wait);
            }
            else if (step is SwitchToiFrame)
            {
                return new SwitchToiFrameRunner(step as SwitchToiFrame);
            }
            else if (step is AssertElementNotPresent)
            {
                return new AssertElementNotPresentRunner(step as AssertElementNotPresent);
            }
            else if (step is SetCheckbox)
            {
                return new SetCheckboxRunner(step as SetCheckbox);
            }
            else if (step is CompareImage)
            {
                return new CompareImageRunner(step as CompareImage);
            }
            else if (step is SendKeysAndEnter)
            {
                return new SendKeysAndEnterRunner(step as SendKeysAndEnter);
            }
            else
            {
                throw new Exception(string.Format("Could not create a runner for step of type {0}", step.GetType().Name));
            }
        }
    }
}