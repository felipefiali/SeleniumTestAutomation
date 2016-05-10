namespace TestRunner
{
    using System;
    using System.Threading;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class WaitRunner : StepRunner
    {
        private Wait WaitStep { get; set; }

        public WaitRunner(Wait step, Driver driver)
            : base(step, driver)
        {
            WaitStep = step;
        }

        public override IStepResult Run()
        {
            Thread.Sleep(TimeSpan.FromSeconds(WaitStep.Seconds));

            return StepResult;
        }
    }
}