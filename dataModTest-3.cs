using Microsoft.VisualStudio.TestTools.UnitTesting;
using P3;
using System;

namespace dataModTest
{
    [TestClass]
    public class dataModTest
    {
        int[] defaultArr = new int[5] { 3, 7, 9, 4, 24 };
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
        public void testFilter_LargeMode_IncrementsArrayValues()
        {
            int[] dataModArrTest = defaultArr;
            dataMod obj = new dataMod(7, dataModArrTest);
            int[] returnedArr = obj.filter();
            Assert.IsTrue(returnedArr.Length == 2);
            Assert.IsTrue(returnedArr[0] == 10);
            Assert.IsTrue(returnedArr[1] == 25);
        }

        [TestMethod]
        public void testFilter_SmallMode_DecrementsArrayValues()
        {
            int[] dataModArrTest = defaultArr;
            dataMod obj = new dataMod(7, dataModArrTest);
            obj.toggleMode();
            int[] returnedArr = obj.filter();
            Assert.IsTrue(returnedArr.Length == 2);
            Assert.IsTrue(returnedArr[0] == 2);
            Assert.IsTrue(returnedArr[1] == 3);
        }

        [TestMethod]
        public void testScramble_SetsPrimesTo2()
        {
            int[] dataModArrTest = defaultArr;
            int[] correctResult = new int[5] { 2, 2, 9, 4 , 24};
            dataMod obj = new dataMod(7, dataModArrTest);
            int[] returnedArr = obj.scramble(dataModArrTest);
            for (int i = 0; i < returnedArr.Length; i++) { Assert.AreEqual(returnedArr[i], correctResult[i]); }
        }
    }
}
