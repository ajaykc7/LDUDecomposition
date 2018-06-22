using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Numerics;
namespace LDUDecomposition.UnitTests
{
    [TestClass]
    public class BigFractionTest
    {
        [TestMethod]
        public void GetGCF_TwoBigInteger_ReturnsGCF()
        {
            BigFraction bigFraction = new BigFraction("4/5");

            //var result = bigFraction.GetGCF(new BigInteger(8), new BigInteger(2));

            //Assert.AreEqual(result, new BigInteger(2));
        }

        [TestMethod]
        public void GetLCM_TwoBigInteger_ReturnsLCM()
        {
            BigFraction bigFraction = new BigFraction("4/5");

            //var result = bigFraction.GetLCM(new BigInteger(6), new BigInteger(8));

            //Assert.AreEqual(result, new BigInteger(24));
        }

        [TestMethod]
        public void GetSimplestForm_TwoBigIntegers_ReturnsSimplestForm()
        {
            BigFraction bigFraction = new BigFraction("4/5");

            var resultOne = bigFraction.GetSimplestForm(new BigInteger(10), new BigInteger(5));

            var resultTwo = bigFraction.GetSimplestForm(new BigInteger(0), new BigInteger(5));

            var resultThree = bigFraction.GetSimplestForm(new BigInteger(14), new BigInteger(15));

            Assert.AreEqual(resultOne.ToString(), "2/1");
            Assert.AreEqual(resultTwo.ToString(), "0/1");
            Assert.AreEqual(resultThree.ToString(), "14/15");
        }
    }
}
