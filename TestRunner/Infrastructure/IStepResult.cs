namespace TestRunner.Infrastructure
{
    using System.Collections.Generic;
    using TestStructure;

    public interface IStepResult
    {
        Step Step { get; }

        TestStepExecutionException Exception { get; }

        bool IsSuccessful();

        IEnumerable<IStepResult> SubStepsResults { get; }

        bool IsSubStep { get; set; }
    }
}