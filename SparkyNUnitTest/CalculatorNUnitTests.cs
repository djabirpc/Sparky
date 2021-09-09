﻿using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //Arrange
            Calcolator calc = new();

            //Act
            int result = calc.AddNumbers(10, 20);

            //Assert
            Assert.AreEqual(30, result);
        }
    
        [Test]
        public void IsOddNumber_InputEvenNumber_ReturnFalse()
        {
            Calcolator calc = new();

            bool isOdd = calc.IsOddNumber(10);
            Assert.That(isOdd, Is.EqualTo(false));
            Assert.IsFalse(isOdd);
        }

        [Test]
        [TestCase(11)]
        [TestCase(13)]
        public void IsOddNumber_InputEvenNumber_ReturnTrue(int a)
        {
            Calcolator calc = new();

            bool isOdd = calc.IsOddNumber(a);
            Assert.That(isOdd, Is.EqualTo(true));
            Assert.IsTrue(isOdd);
        }

        [Test]
        [TestCase(10,ExpectedResult = false)]
        [TestCase(11,ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueIfOdd(int a)
        {
            Calcolator calc = new();
            return calc.IsOddNumber(a);
        }

        [Test]
        [TestCase(5.4,10.5)] //15.9
        [TestCase(5.43,10.53)] //15.93
        [TestCase(5.49,10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a,double b)
        {
            //Arrange
            Calcolator calc = new();

            //Act
            double result = calc.AddNumbersDouble(a, b);

            //Assert
            Assert.AreEqual(15.9, result,.2);
            //[15.7,16.1] for .2 , c comme un interval
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            Calcolator calc = new();
            List<int> expectedOddRange = new() { 5, 7, 9 }; // 5-10

            //act
            List<int> result = calc.GetOddRange(5, 10);

            //assert
            Assert.That(result, Is.EquivalentTo(expectedOddRange));
        }
    
        
    }
}
