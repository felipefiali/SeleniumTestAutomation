namespace Tests
{
    using TestRunner;
    using TestRunner.Infrastructure;

    public abstract class TestBase
    {
        protected void ExecuteTest(string fullTestFilePath)
        {
            var deserializedTest = TestDeserializer.DeserializeTest(fullTestFilePath);

            using (var runner = new TestRunner(deserializedTest))
            {
                var result = runner.RunTest();

                if (!result.IsSuccessful())
                {
                    ReportFailure(fullTestFilePath, result);
                }
            }
        }

        private void ReportFailure(string fileName, ITestResult result)
        {
            throw new TestFailureException(fileName, result.GetFailedSteps());
        }
    }
}