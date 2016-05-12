namespace TestStructure
{
    public class AssertAttributeValue : Step
    {
        public string ElementCssPath { get; set; }

        public string ElementHint { get; set; }

        public string AttributeName { get; set; }

        public string ExpectedValue { get; set; }

        public string ErrorMessage { get; set; }
    }
}