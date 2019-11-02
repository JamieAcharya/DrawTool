using System;
using DrawTool;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrawToolUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        Form1 Form1 = new Form1();

        [TestMethod]
        public void TestMethod1()
        {
            
        }
        [TestMethod]
        public void Circle_Negative_Parameters()
        {
            // arrange
            float givenSize = -50;
            bool expected = false;

            // act
            bool actual = Form1.ValidateCircleSize(givenSize);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
