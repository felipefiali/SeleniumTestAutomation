namespace TestRunner
{
    using System;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public abstract class StepRunner
    {   
        protected StepResult StepResult { get; set; }

        public StepRunner(Step step)
        {
            StepResult = new StepResult(step);
        }

        public abstract IStepResult Run(Driver driver);

        protected TestStepExecutionException HandleException(Exception ex, FailureType failureType)
        {
            return TestStepExecutionExceptionFactory.ConstructByFailureType(failureType, ex.Message, ex);
        }

        protected TestStepExecutionException HandleException(string message, FailureType failureType)
        {
            return TestStepExecutionExceptionFactory.ConstructByFailureType(failureType, message);
        }

        protected TestStepExecutionException HandleAssertionException(string message, string expectedValue, string actualValue)
        {
            message = string.Format("Expected value: {0}; Actual value: {1}; {2}", expectedValue, actualValue, message);

            return TestStepExecutionExceptionFactory.ConstructByFailureType(FailureType.Assertion, message);
        }

        protected TestStepExecutionException HandleImageComparisonException(string expectedMd5Hash, string actualMd5Hash)
        {
            var message = string.Format("The image comparison failed. Expected calculated MD5 Hash: {0}; Actual calculated MD5 Hash: {1}", expectedMd5Hash, actualMd5Hash);

            return TestStepExecutionExceptionFactory.ConstructByFailureType(FailureType.ImageComparison, message);
        }
    }
}