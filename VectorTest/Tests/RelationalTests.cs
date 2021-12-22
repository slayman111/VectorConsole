using Microsoft.VisualStudio.TestTools.UnitTesting;
using VectorConsole.Core;

namespace Tests.VectorTest
{
    [TestClass]
    public class RelationalTests
    {
        [TestMethod]
        public void VectorEquality_111Equal111_True()
        {
            Assert.AreEqual(true, new Vector(1, 1, 1) == new Vector(1, 1, 1));
        }

        [TestMethod]
        public void VectorEquality_111Equal123_False()
        {
            Assert.AreEqual(false, new Vector(1, 1, 1) == new Vector(1, 2, 3));
        }

        [TestMethod]
        public void VectorInequality_111Inequal123_True()
        {
            Assert.AreEqual(true, new Vector(1, 1, 1) != new Vector(1, 2, 3));
        }

        [TestMethod]
        public void VectorInequality_111Inequal111_False()
        {
            Assert.AreEqual(false, new Vector(1, 1, 1) != new Vector(1, 1, 1));
        }

        [TestMethod]
        public void VectorGreaterThan_111GreaterThanl111_False()
        {
            Assert.AreEqual(false, new Vector(1, 1, 1) > new Vector(1, 1, 1));
        }

        [TestMethod]
        public void VectorGreaterThan_123GreaterThanl111_True()
        {
            Assert.AreEqual(true, new Vector(1, 2, 3) > new Vector(1, 1, 1));
        }

        [TestMethod]
        public void VectorGreaterThanOrEqualTo_111GreaterThanOrEqualTol111_True()
        {
            Assert.AreEqual(true, new Vector(1, 1, 1) >= new Vector(1, 1, 1));
        }

        [TestMethod]
        public void VectorGreaterThanOrEqualTo_123GreaterThanOrEqualTol111_True()
        {
            Assert.AreEqual(true, new Vector(1, 2, 3) >= new Vector(1, 1, 1));
        }

        [TestMethod]
        public void VectorGreaterThanOrEqualTo_111GreaterThanOrEqualTol123_False()
        {
            Assert.AreEqual(false, new Vector(1, 1, 1) >= new Vector(1, 2, 3));
        }

        [TestMethod]
        public void VectorLessThan_111LessThan111_False()
        {
            Assert.AreEqual(false, new Vector(1, 1, 1) < new Vector(1, 1, 1));
        }

        [TestMethod]
        public void VectorLessThan_111LessThan123_True()
        {
            Assert.AreEqual(true, new Vector(1, 1, 1) < new Vector(1, 2, 3));
        }

        [TestMethod]
        public void VectorLessThanOrEqualTo_111LessThanOrEqualTo111_True()
        {
            Assert.AreEqual(true, new Vector(1, 1, 1) <= new Vector(1, 1, 1));
        }

        [TestMethod]
        public void VectorLessThanOrEqualTo_111LessThanOrEqualTo123_True()
        {
            Assert.AreEqual(true, new Vector(1, 1, 1) <= new Vector(1, 2, 3));
        }

        [TestMethod]
        public void VectorLessThanOrEqualTo_123LessThanOrEqualTo111_False()
        {
            Assert.AreEqual(false, new Vector(1, 2, 3) <= new Vector(1, 1, 1));
        }
    }
}
