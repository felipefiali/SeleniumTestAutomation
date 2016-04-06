namespace TestRunner.Infrastructure
{
    using System;
    using System.Collections.Generic;

    public class TestFailureException : Exception
    {
        public IEnumerable<IStepResult> FailedTestSteps { get; set; }
        public string TestFile { get; set; }

        private string message;

        public TestFailureException(string testFile, IEnumerable<IStepResult> failedTestSteps)            
        {
            FailedTestSteps = failedTestSteps;
            TestFile = testFile;
        }

        public override string Message
        {
            get
            {
                if (string.IsNullOrEmpty(message))
                {
                    message = ConstructFullMessage();
                }

                return message;
            }
        }

        private string ConstructFullMessage()
        {
            string message = string.Format("At least one test step has failed for test {0}:{1}", TestFile, Environment.NewLine);

            foreach (var failedStep in FailedTestSteps)
            {
                message += failedStep.ToString() + Environment.NewLine;
            }

            return message;
        }
    }
}
