namespace TestRunner.Infrastructure
{
    using System;
    using TestStructure;

    public class ElementShouldNotBePresentException : TestStepExecutionException
    {
        public ElementShouldNotBePresentException(string message)
            : base(message)
        {

        }

        public ElementShouldNotBePresentException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}