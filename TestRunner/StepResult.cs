namespace TestRunner
{
    using System.Collections.Generic;
    using Infrastructure;
    using TestStructure;

    public class StepResult : IStepResult
    {
        private List<IStepResult> subStepsResults;

        private TestStepExecutionException exception;

        private bool Success { get; set; }

        public TestStepExecutionException Exception
        {
            get
            {
                return exception;
            }
            set
            {
                Success = false;

                exception = value;
            }
        }

        public Step Step { get; private set; }

        public IEnumerable<IStepResult> SubStepsResults
        {
            get
            {
                return subStepsResults;
            }
        }

        public bool IsSubStep { get; set; }

        public StepResult(Step step)
        {
            Step = step;

            Success = true;

            subStepsResults = new List<IStepResult>();
        }

        public bool IsSuccessful()
        {
            return Success;
        }

        public void AddSubStepResult(IStepResult SubStepResult)
        {
            SubStepResult.IsSubStep = true;

            if (!SubStepResult.IsSuccessful())
            {
                Success = false;
            }

            subStepsResults.Add(SubStepResult);
        }

        public override string ToString()
        {
            var objectString = string.Format("Step order: {0}; Type: {1}; Success: {2}; Is sub step: {3};", Step.Order, Step.GetType().Name, Success.ToString(), IsSubStep.ToString());

            if (!Success)
            {
                objectString += string.Format(" Exception type: {0}; Exception message: {1};", Exception.GetType().Name, Exception.Message);
            }

            return objectString;
        }
    }
}