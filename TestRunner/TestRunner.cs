namespace TestRunner
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Driver;
    using Infrastructure;
    using TestStructure;

    public class TestRunner : IDisposable
    {
        private Driver Driver { get; set; }

        private Test Test { get; set; }

        private TestResult TestResult { get; set; }

        public TestRunner(Test test)
        {
            Test = test;

            TestResult = new TestResult(test);

            Driver = new Driver();
        }

        public ITestResult RunTest()
        {
            foreach (var step in GetOrderedSteps())
            {
                var stepResult = StepRunnerFactory.Construct(step).Run(Driver);

                TestResult.AddStepResult(stepResult);
            }

            return TestResult;
        }

        private IEnumerable<Step> GetOrderedSteps()
        {
            return from step in Test.Steps
                   orderby step.Order ascending
                   select step;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (Driver != null)
                    {
                        Driver.Dispose();
                    }
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {            
            Dispose(true);            
        }
        #endregion
    }
}