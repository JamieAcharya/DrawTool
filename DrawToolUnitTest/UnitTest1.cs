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
        /*
         * Tests if moveTo coordinates are postive
         */
        [TestMethod]
        public void MoveTo_Negative_Parameters_Valid()
        {
            float moveTo_x = 50;
            float moveTo_y = 50;
            bool converted = true;

            bool actual = Form1.ConvertMoveto(moveTo_x.ToString(), moveTo_y.ToString());

            Assert.AreEqual(converted, actual);
        }
        /*
         * Tests if moveTo coordinates are negative
         */
        [TestMethod]
        public void MoveTo_Negative_Parameters_Invalid()
        {
            float moveTo_x = -50;
            float moveTo_y = -50;
            bool converted = false;

            bool actual = Form1.ValidateMoveTo(moveTo_x, moveTo_y);

            Assert.AreEqual(converted, actual);
        }

        /*
         * Tests if the circle size parameter is negative
         */
        [TestMethod]
        public void Circle_Has_Negative_Parameters_Invalid()
        {
            // arrange
            float givenSize = -50;
            bool converted = false;

            // act
            bool actual = Form1.ValidateCircleSize(givenSize);

            // assert
            Assert.AreEqual(converted, actual);
        }

        [TestMethod()]
        [ExpectedException(typeof(FormatException))]
        public void Circle_WithIncorrectRadiusFormat_Invalid()
        {
            // arrange
            string givenSize = "fifty";
            bool converted = false;

            // act
            bool actual = Form1.ValidateCircleSize((float)Convert.ToDouble(givenSize));

            //assert
            Assert.AreEqual(converted, actual);
        }

    }
}
