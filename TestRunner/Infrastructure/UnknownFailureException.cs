namespace TestRunner.Infrastructure
{
    using System;
    using TestStructure;

    public class UnknownFailureException : TestStepExecutionException
    {
        public UnknownFailureException(string message)
            : base(message)
        {

        }

        public UnknownFailureException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}