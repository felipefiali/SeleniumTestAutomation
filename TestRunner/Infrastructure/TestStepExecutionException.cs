namespace TestStructure
{
    using System;

    public class TestStepExecutionException : Exception
    {
        public TestStepExecutionException(string message)
            : base(message)
        {            
        }

        public TestStepExecutionException(string message, Exception innerException)
            : base(message, innerException)
        {            
        }
    }
}