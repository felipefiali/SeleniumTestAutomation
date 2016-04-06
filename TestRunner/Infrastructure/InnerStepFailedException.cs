﻿namespace TestRunner.Infrastructure
{
    using System;
    using TestStructure;

    public class SubStepFailedException : TestStepExecutionException
    {
        public SubStepFailedException(string message)
            : base(message)
        {

        }

        public SubStepFailedException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}