namespace TestRunner.Infrastructure
{
    using System;
    using TestStructure;

    public class ImageComparisonException : TestStepExecutionException
    {
        public ImageComparisonException(string message)
            : base(message)
        {

        }

        public ImageComparisonException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}