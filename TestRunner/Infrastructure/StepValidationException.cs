namespace TestRunner.Infrastructure
{
    using System;
    using TestStructure;

    public class StepValidationException : TestStepExecutionException
    {
        public StepValidationException(string message)
            : base(message)
        {

        }

        public StepValidationException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}