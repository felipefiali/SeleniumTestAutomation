namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;
    using System.Linq;
    using System.Collections.Generic;

    public class SwitchToiFrameRunner : StepRunner
    {
        private SwitchToiFrame SwitchToIframeStep { get; set; }

        public SwitchToiFrameRunner(SwitchToiFrame step, Driver driver)
            : base(step, driver)
        {
            SwitchToIframeStep = step;
        }

        public override IStepResult Run()
        {
            try
            {
                Driver.SwitchToiFrame(SwitchToIframeStep.iFrameCssPath, SwitchToIframeStep.ElementHint);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            if (StepResult.IsSuccessful())
            {
                ExecuteSubSteps();

                Driver.SwitchToDefaultContent();
            }

            return StepResult;
        }

        private IStepResult ExecuteSubSteps()
        {
            try
            {
                foreach (var step in GetOrderedSteps())
                {
                    var SubStepResult = StepRunnerFactory.Construct(step, Driver).Run();

                    if (!SubStepResult.IsSuccessful() && StepResult.Exception == null)
                    {
                        StepResult.Exception = HandleException("At least one sub step has failed.", FailureType.SubStepFailed);
                    }

                    StepResult.AddSubStepResult(SubStepResult);
                }
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.ElementNotFound);
            }

            return StepResult;
        }

        private IEnumerable<Step> GetOrderedSteps()
        {
            return from step in SwitchToIframeStep.Steps
                   orderby step.Order ascending
                   select step;
        }
    }
}
