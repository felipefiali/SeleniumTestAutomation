namespace TestStructure
{
    using System.Collections.Generic;
    using System.Xml.Serialization;

    public class SwitchToiFrame : Step
    {
        [XmlAttribute]
        public string iFrameCssPath { get; set; }

        [XmlAttribute]
        public string ElementHint { get; set; }

        private int CurrentStepCounter { get; set; }

        public SwitchToiFrame()
        {
            CurrentStepCounter = 1;

            Steps = new List<Step>();
        }

        [XmlArray]
        [XmlArrayItem(Type = typeof(AssertValue))]
        [XmlArrayItem(Type = typeof(Click))]
        [XmlArrayItem(Type = typeof(ClickIfFound))]
        [XmlArrayItem(Type = typeof(Navigate))]        
        [XmlArrayItem(Type = typeof(TypeText))]
        [XmlArrayItem(Type = typeof(SelectDropDownItem))]
        [XmlArrayItem(Type = typeof(Wait))]        
        [XmlArrayItem(Type = typeof(SwitchToiFrame))]
        public List<Step> Steps { get; set; }       

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