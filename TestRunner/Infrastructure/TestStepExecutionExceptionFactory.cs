namespace TestRunner.Infrastructure
{
    using System;
    using TestStructure;

    public static class TestStepExecutionExceptionFactory
    {
        public static TestStepExecutionException ConstructByFailureType(FailureType failureType, string message, Exception innerException)
        {
            switch (failureType)
            {
                case FailureType.Assertion:
                    return new AssertException(message, innerException);

                case FailureType.ElementNotFound:
                    return new ElementNotFoundException(message, innerException);                    

                case FailureType.Unknown:
                    return new UnknownFailureException(message, innerException);                    

                case FailureType.SubStepFailed:
                    return new SubStepFailedException(message, innerException);

                case FailureType.ElementShouldNotBePresent:
                    return new ElementShouldNotBePresentException(message, innerException);

                case FailureType.ImageComparison:
                    return new ImageComparisonException(message, innerException);

                case FailureType.StepValidation:
                    return new StepValidationException(message, innerException);

                default:
                    throw new Exception(string.Format("Could not create TestStepExecutionException for failure type {0}", failureType));
            }
        }

        public static TestStepExecutionException ConstructByFailureType(FailureType failureType, string message)
        {
            return ConstructByFailureType(failureType, message, null);
        }        
    }
}