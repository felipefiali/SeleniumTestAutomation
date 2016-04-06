namespace TestRunner.Infrastructure
{
    using System;
    using TestStructure;

    public class AssertException : TestStepExecutionException
    {
        public AssertException(string message)
            : base(message)
        {

        }

        public AssertException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}