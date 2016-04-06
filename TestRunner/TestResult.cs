namespace TestRunner
{
    using System.Collections.Generic;
    using System.Linq;
    using Infrastructure;
    using TestStructure;

    public class TestResult : ITestResult
    {
        private IList<IStepResult> stepsResults;

        private bool Success { get; set; }

        public IEnumerable<IStepResult> StepsResults
        {
            get
            {
                return stepsResults;
            }
        }

        public Test Test { get; private set; }

        public TestResult(Test test)
        {
            Test = test;

            stepsResults = new List<IStepResult>();

            Success = true;
        }

        public IEnumerable<IStepResult> GetFailedSteps()
        {
            var failedStepResults = from stepResult in StepsResults
                                    where !stepResult.IsSuccessful()
                                    select stepResult;

            var failedSubStepResults = failedStepResults.SelectMany(sr => sr.SubStepsResults).Where(isr => !isr.IsSuccessful());

            var list = new List<IStepResult>(failedStepResults);

            list.AddRange(failedSubStepResults);

            return list;
        }

        public bool IsSuccessful()
        {
            return Success;
        }

        public void AddStepResult(IStepResult stepResult)
        {
            if (!stepResult.IsSuccessful())
            {
                Success = false;
            }

            stepsResults.Add(stepResult);
        }
    }
}
