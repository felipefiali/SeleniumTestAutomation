namespace Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class Tests : TestBase
    {
        [TestMethod]
        public void SampleTestMethod()
        {
            ExecuteTest(@"C:\SomeTestXml.xml");
        }
    }
}
