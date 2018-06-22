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
            BigFraction bigFraction = new BigFraction("2/4");

            //var result = bigFraction.GetGCF(new BigInteger(2), new BigInteger(-4));

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
            BigFraction bigFraction = new BigFraction("0/5");

            /*var resultOne = bigFraction.GetSimplestForm(bigFraction);

            Assert.AreEqual(resultOne.ToString(), "2/1");*/
        }

        [TestMethod]
        public void Add_TwoBigFraction_ReturnsAdditionResult()
        {
            BigFraction fractionA = new BigFraction("4/5");
            BigFraction fractionB = new BigFraction("3/7");
            var resultOne = fractionA.Add(fractionB);

            Assert.AreEqual(resultOne.ToString(), "43/35");
        }

        [TestMethod]
        public void Subtract_TwoBigFraction_ReturnSubtractionResult()
        {
            BigFraction fractionA = new BigFraction("4/5");
            BigFraction fractionB = new BigFraction("0/1");

            var resultOne = fractionA.Subtract(fractionB);
            Assert.AreEqual(resultOne.ToString(), "4/5");
        }

        [TestMethod]
        public void Multiply_TwoBigFraction_ReturnsMultiplicationResult()
        {
            BigFraction fractionA = new BigFraction("4/5");
            BigFraction fractionB = new BigFraction("2/4");

            var result = fractionA.Multiply(fractionB);
            Assert.AreEqual(result.ToString(), "2/5");
        }

        [TestMethod]
        public void Divide_TwoBigFraction_ReturnsDivisionResult()
        {
            BigFraction fractionA = new BigFraction("4/5");
            BigFraction fractionB = new BigFraction("-2/4");

            var result = fractionA.Divide(fractionB);
            Assert.AreEqual(result.ToString(), "-8/5");
        }
    }
}
