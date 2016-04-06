namespace TestRunner.Infrastructure
{
    using System.Collections.Generic;
    using TestStructure;

    public interface ITestResult
    {
        Test Test { get; }

        IEnumerable<IStepResult> StepsResults { get; }

        IEnumerable<IStepResult> GetFailedSteps();

        void AddStepResult(IStepResult stepResult);

        bool IsSuccessful();
    }
}
