using Microsoft.VisualStudio.TestTools.UnitTesting;
using P3;
using System;

namespace dataFilterTest
{
    [TestClass]
    public class dataFilterTest
    {
        int[] defaultArr = new int[3] { 3, 7, 9 };
        int[] defaultArr2 = new int[5] { 3, 7, 9, 4, 24 };
        int[] defaultArr3 = new int[4] { 3, 7, 11, 9 };
        int[] negativeArr = new int[5] { -67, -91, -5, -2, -3 };

        [TestMethod]
        public void testConstructorAndFilter_NonPrimeLargeMode_SetsNearbyPrime()
        {
            int[] arr = defaultArr3;
            dataFilter obj = new dataFilter(6, arr);
            int[] returnedArr = obj.filter();
            Assert.IsTrue(returnedArr[0] == 11);
            Assert.IsTrue(returnedArr[1] == 9);
            Assert.IsTrue(returnedArr.Length == 2);
        }

        [TestMethod]
        public void testConstructor_NegativeValues_SetsNegativesToPositive()
        {
            int[] correctResult = new int[2] { 67, 91 };
            int[] negArr = negativeArr;
            dataFilter obj = new dataFilter(-6, negArr);
            int[] returnedArr = obj.filter();
            for (int i = 0; i < returnedArr.Length; i++) { Assert.AreEqual(returnedArr[i], correctResult[i]); };
        }

        [TestMethod]
        public void testConstructor_InvalidArr_ThrowsException()
        {
            int[] invalidArr = new int[1] { 0 };
            dataFilter obj;
            Assert.ThrowsException<ArgumentException>(() => obj = new dataFilter(7, invalidArr));
        }

        [TestMethod]
        public void testFilter_SmallMode_ReturnsCorrectSequence()
        {
            int[] arr = defaultArr3;
            dataFilter obj = new dataFilter(7, arr);
            obj.toggleMode();
            int[] returnedArr = obj.filter();
            Assert.IsTrue(returnedArr[0] == 3);
        }

        [TestMethod]
        public void testScramble_LargeMode_ReturnsCorrectSequence()
        {
            int[] arr = defaultArr2;
            dataFilter obj = new dataFilter(7, arr);
            int[] returnedArr = obj.scramble(defaultArr);
            Assert.IsTrue(returnedArr.Length == 3);
            Assert.IsTrue(returnedArr[0] == 7);
            Assert.IsTrue(returnedArr[1] == 3);
            Assert.IsTrue(returnedArr[2] == 9);
        }

        [TestMethod]
        public void testScramble_SmallMode_ReturnsCorrectSequence()
        {
            int[] arr = defaultArr2;
            dataFilter obj = new dataFilter(7, arr);
            obj.toggleMode();
            int[] returnedArr = obj.scramble(defaultArr);
            Assert.IsTrue(returnedArr.Length == 3);
            Assert.IsTrue(returnedArr[0] == 3);
            Assert.IsTrue(returnedArr[1] == 7);
            Assert.IsTrue(returnedArr[2] == 9);
        }


    }
}
