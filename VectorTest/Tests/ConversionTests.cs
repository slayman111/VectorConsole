using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorConsole.Core;

namespace VectorTest.Tests
{
    [TestClass]
    public class ConversionTests
    {
        [TestMethod]
        public void VectorToDouble_111ToDouble_10()
        {
            Assert.AreEqual(new Vector(1, 1, 1), new Vector(1, 1, 1).GetLength());
        }
    }
}
