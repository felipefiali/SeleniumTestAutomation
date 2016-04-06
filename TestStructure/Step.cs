using System.Xml.Serialization;

namespace TestStructure
{
    public abstract class Step
    {
        [XmlAttribute]
        public int Order { get; set; }
    }
}