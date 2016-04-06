namespace TestStructure
{
    public class AssertValue : Step
    {
        public string ElementCssPath { get; set; }

        public string ExpectedValue { get; set; }

        public string ErrorMessage { get; set; }

        public string ElementHint { get; set; }
    }
}
