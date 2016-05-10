namespace TestRunner.Infrastructure
{
    internal interface IValidateStepExecution
    {
        /// <summary>
        /// Validates the execution of a test step and throws an exception if the validation fails.
        /// </summary>
        bool ValidateExecution();
    }
}
