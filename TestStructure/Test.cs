namespace TestStructure
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class Test
    {
        private int CurrentStepCounter { get; set; }               

        [XmlArray]
        [XmlArrayItem(Type = typeof(AssertValue))]
        [XmlArrayItem(Type = typeof(Click))]
        [XmlArrayItem(Type = typeof(ClickIfFound))]
        [XmlArrayItem(Type = typeof(Navigate))]        
        [XmlArrayItem(Type = typeof(TypeText))]
        [XmlArrayItem(Type = typeof(SelectDropDownItem))]
        [XmlArrayItem(Type = typeof(Wait))]        
        [XmlArrayItem(Type = typeof(SwitchToiFrame))]
        [XmlArrayItem(Type = typeof(AssertElementNotPresent))]
        [XmlArrayItem(Type = typeof(SetCheckbox))]
        [XmlArrayItem(Type = typeof(CompareImage))]
        [XmlArrayItem(Type = typeof(SendKeysAndEnter))]
        [XmlArrayItem(Type = typeof(AssertAttributeValue))]
        public List<Step> Steps { get; set; }

        public Test()
        {
            CurrentStepCounter = 1;

            Steps = new List<Step>();
        }

        public void AddStep(Step step)
        {
            step.Order = CurrentStepCounter;            

            Steps.Add(step);

            IncrementStepCounter();
        }

        private void IncrementStepCounter()
        {
            CurrentStepCounter++;
        }
    }
}
