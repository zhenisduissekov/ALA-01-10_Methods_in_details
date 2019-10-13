using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCD_with_multiple_inputs;


namespace FindGCDTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GCD_test()
        {
            // arrange
            int[] a = { 100, 22, 44, 2, 1000 };
            int expected = 2;
            // act
           
            int actual = FindGCD.MyGCD(a);
            // assert
            Assert.AreEqual(actual, expected);
        }

        [TestMethod]
        public void binary_GCD_test()
        {
            // arrange
            int[] a = { 100, 22, 44, 2, 1000 };
            int expected = 2;
            // act

            int actual = FindGCD.MyBinaryGCD(a);
            // assert
            Assert.AreEqual(actual, expected);
        }
    }
}
