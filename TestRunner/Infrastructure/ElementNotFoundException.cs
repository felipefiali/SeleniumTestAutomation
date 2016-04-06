namespace TestRunner.Infrastructure
{
    using System;
    using TestStructure;

    public class ElementNotFoundException : TestStepExecutionException
    {
        public ElementNotFoundException(string message)
            : base(message)
        {

        }

        public ElementNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}