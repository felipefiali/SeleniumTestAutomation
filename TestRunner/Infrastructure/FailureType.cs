namespace TestRunner.Infrastructure
{
    public enum FailureType
    {
        Assertion,
        ElementNotFound,
        Unknown,
        SubStepFailed,
        ElementShouldNotBePresent,
        ImageComparison
    }
}