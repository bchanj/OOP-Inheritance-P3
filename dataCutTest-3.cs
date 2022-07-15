using Microsoft.VisualStudio.TestTools.UnitTesting;
using P3;
using System;

namespace dataCutTest
{
    [TestClass]
    public class dataCutTest
    {
        int[] defaultArr = new int[3] { 7, 9, 24 };
        int[] defaultArr2 = new int[5] { 3, 7, 9, 4, 24 };
        int[] negativeArr = new int[5] { -67, -91, -5, -2, -3 };

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
        public void testConstructor_InvalidSequence_ThrowsException() 
        {
            int[] invalidArr = new int[3] { 1, 2, 3 };
            dataCut obj;
            Assert.ThrowsException<ArgumentException>(() => obj = new dataCut(7, invalidArr));
        }

        [TestMethod]
        public void testScramble_InvalidSequence_ThrowsException()
        {
            int[] arr = new int[5] { 1, 2, 3 , 4, 5};
            int[] test = new int[4] { 1, 2, 3, 4 };
            dataCut obj = new dataCut(2, defaultArr2);
            obj.scramble(test);
            obj.scramble(arr);
            Assert.ThrowsException<ArgumentException>(() => obj.scramble(defaultArr));
        }

        [TestMethod]
        public void testFilter_NullSequence_ReturnsEncapsulatedPrime()
        {
            int[] arr = new int[4] { 1, 2, 3, 4 };
            dataCut obj = new dataCut(7, arr);
            obj.scramble(arr);
            obj.scramble(arr);
            arr = obj.filter();
            Assert.AreEqual(arr[0], 7);
        }

        [TestMethod]
        public void testFilter_LargeMode_RemovesMaxValue()
        {
            int[] correctResult = new int[2] { 9, 7 };
            int[] dataCutArrTest = defaultArr2;
            dataCut obj = new dataCut(5, dataCutArrTest);
            int[] returnedArr = obj.filter();

            Assert.AreEqual(returnedArr.Length, 2);
            for (int i = 0; i < returnedArr.Length; i++)
            {
                Assert.AreEqual(returnedArr[i], correctResult[i]);
            }
        }

        [TestMethod]
        public void testFilter_SmallMode_RemovesLowestValue()
        {
            int[] correctResult = new int[3] { 7, 9, 4 };
            int[] dataCutArrTest = defaultArr2;
            dataCut obj = new dataCut(11, dataCutArrTest);
            obj.toggleMode();
            int[] returnedArr = obj.filter();

            Assert.AreEqual(returnedArr.Length, 3);
            for (int i = 0; i < returnedArr.Length; i++)
            {
                Assert.AreEqual(returnedArr[i], correctResult[i]);
            }

        }

        [TestMethod]
        public void testScramble_MultipleCalls_RemovesValuesFoundInPrevArray()
        {
            int[] test1 = new int[8] { 3, 4, 6, 8, 103, 255, 108, 256 };
            int[] test2 = new int[10] { 4, 6, 103, 255, 108, 256, 800, 900, 10001, 431 };
            int[] test3 = new int[15] { 4, 6, 103, 255, 108, 256, 800, 900, 10001, 431 , 425, 324, 679, 711, 911 };
            int[] correctFirst = new int[8] { 4, 3, 8, 6, 255, 103, 256, 108};
            int[] correctSecond = new int[4] { 900, 800, 10001, 431 };
            int[] correctThree = new int[5] { 425, 324, 711, 679, 911 };

            int[] dataCutArrTest = test1;
            dataCut obj = new dataCut(7, dataCutArrTest);
            dataCutArrTest = obj.scramble(test1);

            for (int i = 0; i < dataCutArrTest.Length; i++) 
            { 
                Assert.AreEqual(dataCutArrTest[i], correctFirst[i]);
            }

            dataCutArrTest = obj.scramble(test2);
            for (int i = 0; i < dataCutArrTest.Length; i++)
            {
                Assert.AreEqual(dataCutArrTest[i], correctSecond[i]);
            }

            dataCutArrTest = obj.scramble(test3);
            for (int i = 0; i < dataCutArrTest.Length; i++)
            {
                Assert.AreEqual(dataCutArrTest[i], correctThree[i]);
            }
        }
    }
}
