using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using VectorConsole.Core;

namespace Tests.VectorTest
{
    [TestClass]
    public class ArithmeticTests
    {
        [TestMethod]
        public void VectorSum_222Sum222_444()
        {
            Assert.AreEqual(new Vector(4, 4, 4), new Vector(2, 2, 2) + new Vector(2, 2, 2));
        }

        [TestMethod]
        public void VectorSum_1111Sum111_LengthDoNotMatch()
        {
            try
            {
                Vector vector = new Vector(1, 1, 1, 1) + new Vector(1, 1, 1);
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is IndexOutOfRangeException);
            }
        }

        [TestMethod]
        public void VectorSubtract_444Subtract222_222()
        {
            Assert.AreEqual(new Vector(2, 2, 2), new Vector(4, 4, 4) - new Vector(2, 2, 2));
        }
        
        [TestMethod]
        public void VectorSubtract_1111Subtract111_LegthDoNotMatch()
        {
            try
            {
                Vector vector = new Vector(1, 1, 1, 1) - new Vector(1, 1, 1);
                Assert.Fail("No exception thrown");
            }
            catch(Exception ex)
            {
                Assert.IsTrue(ex is IndexOutOfRangeException);
            }
        }

        [TestMethod]
        public void VectorMultiply_222Multiply222_444()
        {
            Assert.AreEqual(new Vector(4, 4, 4), new Vector(2, 2, 2) * new Vector(2, 2, 2));
        }

        [TestMethod]
        public void VectorMultiply_1111Multiply111_LegthDoNotMatch()
        {
            try
            {
                Vector vector = new Vector(1, 1, 1, 1) * new Vector(1, 1, 1);
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is IndexOutOfRangeException);
            }
        }

        [TestMethod]
        public void VectorDivide_444Divide222_222()
        {
            Assert.AreEqual(new Vector(2, 2, 2), new Vector(4, 4, 4) / new Vector(2, 2, 2));
        }

        [TestMethod]
        public void VectorDivide_1111Divide111_LegthDoNotMatch()
        {
            try
            {
                Vector vector = new Vector(1, 1, 1, 1) / new Vector(1, 1, 1);
                Assert.Fail("No exception thrown");
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is IndexOutOfRangeException);
            }
        }

        [TestMethod]
        public void VectorIncrement_111Increment_222()
        {
            Vector vector = new Vector(1, 1, 1);
            Assert.AreEqual(new Vector(2, 2, 2), vector++);
        }

        [TestMethod]
        public void VectorIncrement_222Decrement_111()
        {
            Vector vector = new Vector(2, 2, 2);
            Assert.AreEqual(new Vector(1, 1, 1), vector--);
        }
    }
}
