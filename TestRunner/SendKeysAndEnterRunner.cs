﻿namespace TestRunner
{
    using System;
    using System.Windows.Forms;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class SendKeysAndEnterRunner : StepRunner
    {
        private SendKeysAndEnter SendKeysAndEnterStep { get; set; }

        public SendKeysAndEnterRunner(SendKeysAndEnter step)
            : base(step)
        {
            SendKeysAndEnterStep = step;
        }

        public override IStepResult Run(Driver driver)
        {
            const string EnterKey = "{ENTER}";

            try
            {
                SendKeys.SendWait(SendKeysAndEnterStep.Text);
                SendKeys.SendWait(EnterKey);
            }
            catch (Exception ex)
            {
                StepResult.Exception = HandleException(ex, FailureType.Unknown);
            }

            return StepResult;
        }
    }
}