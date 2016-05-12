namespace TestRunner
{
    using System;
    using System.IO;
    using System.Xml.Serialization;
    using TestStructure;

    public static class TestDeserializer
    {
        public static Test DeserializeTest(string fileName)
        {
            var xmlSerializer = new XmlSerializer(typeof(Test), GetTypes());

            Test deserializedTest = null;

            try
            {
                using (var fileStream = new FileStream(new FileInfo(fileName).FullName, FileMode.Open))
                {
                    deserializedTest = (Test)xmlSerializer.Deserialize(fileStream);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("An error occurred when trying to deserialize the test file {0}.", fileName), ex);
            }

            return deserializedTest;
        }

        private static Type[] GetTypes()
        {
            return new Type[]
            {
                typeof(Navigate),
                typeof(Click),
                typeof(ClickIfFound),
                typeof(AssertValue),
                typeof(Step),
                typeof(Wait),
                typeof(SelectDropDownItem),
                typeof(SwitchToiFrame),
                typeof(AssertElementNotPresent),
                typeof(SetCheckbox),
                typeof(CompareImage),
                typeof(SendKeysAndEnter),
                typeof(AssertAttributeValue)
            };
        }
    }
}
