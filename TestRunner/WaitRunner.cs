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

        public WaitRunner(Wait step)
            : base(step)
        {
            WaitStep = step;
        }

        public override IStepResult Run(Driver driver)
        {
            Thread.Sleep(TimeSpan.FromSeconds(WaitStep.Seconds));

            return StepResult;
        }
    }
}