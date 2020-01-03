
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GCDCalculation.Tests
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Inputs_4_8_Returns_4()
        {
            Assert.AreEqual((uint)4, GCDHelper.GCD(4,8));
        }


        [TestMethod]
        public void Inputs_N_N_Returns_N()
        {
            Assert.AreEqual((uint)23623, GCDHelper.GCD(23623, 23623));
            Assert.AreEqual((uint)1212, GCDHelper.GCD(1212, 1212));
            Assert.AreEqual((uint)22734, GCDHelper.GCD(22734, 22734));
        }


        [TestMethod]
        public void Inputs_0_N_Returns_N()
        {
            Assert.AreEqual((uint)26, GCDHelper.GCD(0, 26));
            Assert.AreEqual((uint)77, GCDHelper.GCD(0, 77));
            Assert.AreEqual((uint)3247, GCDHelper.GCD(0, 3247));
            Assert.AreEqual((uint)123547, GCDHelper.GCD(0, 123547));
            Assert.AreEqual((uint)12574585, GCDHelper.GCD(0, 12574585));
            Assert.AreEqual((uint)1241, GCDHelper.GCD(0, 1241));
            Assert.AreEqual((uint)125347, GCDHelper.GCD(0, 125347));
            Assert.AreEqual((uint)124215, GCDHelper.GCD(0, 124215));
            Assert.AreEqual(uint.MaxValue, GCDHelper.GCD(0, uint.MaxValue));

        }

        [TestMethod]
        public void Inputs_0_0_Returns_0()
        {
            Assert.AreEqual((uint)0, GCDHelper.GCD(0, 0));
        }
        [TestMethod]
        public void Inputs_0_0_0_Returns_0()
        {
            Assert.AreEqual((uint)0, GCDHelper.GCD(0, 0, 0));
        }
    }
}
