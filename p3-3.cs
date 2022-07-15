// Brandon Chan
// p3.cs
// 10/2/20
// CPSC 3200, Professor Dingle, Fall Quarter 2020
// Developed in C# on Visual Studio Enterprise 2019

/* PURPOSE: This driver acts to use and test the dataFilter parent object and its children, dataMod and dataCut. 
 *          It wil test the following:
 *          - toggleMode() which will change the mode of the objects between large and small
 *          - filter() on both the large and small modes at different several points (post/pre scramble)
 *          - scramble(arr) on both the large and small modes
 *          - Test dataFilter, dataMod, and dataCut construction with random encapsulated numbers and arrays
 *          - Provide a readable interface to see printed results from method calls
 */

/* Revisions: 
*  - Version 1.0 - 10/8/20 - Intitial driver for dataFilter object and its children objects dataMod and dataCut
*/


using System;
using System.Collections.Specialized;
using System.Security.Cryptography;

namespace P3
{
    class p3
    {
        const int arraySize = 10;
        const int defRandArrSize = 10;
        const int randArrValLowBound = 5;
        const int randArrValUppBound = 100;
        const int randNumLowBound = 30;
        const int randNumUppBound = 70;

        // Returns a dataFilter object (dataFilter, dataMod, dataCut) according to the number passed in.
        // This allows for population of an array with distinct and varying objects for heterogeneous collections.
        static dataFilter getObject(int place)
        {
            Random rand = new Random();
            int randNum = rand.Next(randNumLowBound, randNumUppBound);
            int[] arr = new int[defRandArrSize];
            for (int i = 0; i < defRandArrSize; i++) { arr[i] = rand.Next(randArrValLowBound, randArrValUppBound); }
            if (place % 3 == 0) {
                return new dataFilter(randNum, arr);
            } else if (place % 3 == 1) {
                return new dataMod(randNum, arr);
            } else {
                return new dataCut(randNum, arr);
            }
        }

        // Prints out the welcome message and the contents of the arrays used for the driver and their contents.
        static void printWelcome()
        {
            Console.WriteLine("==========================");
            Console.WriteLine("=== DATA FILTER DRIVER ===");
            Console.WriteLine("==========================");
            Console.WriteLine();
        }

        // Prints out the results of calls to filter() and scramble(arr) for a dataFilter parent object, testing varying modes.
        static void printResultsDF(dataFilter obj)
        {
            int[] tempArr;
            Random rand = new Random();
            int[] randArr = new int[defRandArrSize];

            Console.Write("\nFilter (Large):                  ");
            tempArr = obj.filter();
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nFilter (Small):                  ");
            obj.toggleMode();
            tempArr = obj.filter();
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nSequence passed into scramble:   ");
            for (int i = 0; i < defRandArrSize; i++) { randArr[i] = rand.Next(5, 95); Console.Write(randArr[i] + " "); }

            Console.Write("\nScramble (Large):                ");
            obj.toggleMode();
            tempArr = obj.scramble(randArr);
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nScramble (Small):                ");
            obj.toggleMode();
            tempArr = obj.scramble(randArr);
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nFilter Post Scramble (Large):    ");
            obj.toggleMode();
            tempArr = obj.filter();
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }
        }

        // Prints out the results of calls to filter() and scramble(arr) for a dataMod child object, testing varying modes.
        static void printResultsDM(dataFilter obj)
        {
            int[] tempArr;
            int[] randArr = new int[defRandArrSize];
            Random rand = new Random();
            Console.Write("\nFilter (Large):                  ");
            tempArr = obj.filter();
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nFilter (Small):                  ");
            obj.toggleMode();
            tempArr = obj.filter();
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }
 
            Console.Write("\nSequence passed into scramble:   ");
            for (int i = 0; i < defRandArrSize; i++) { randArr[i] = rand.Next(5, 95); Console.Write(randArr[i] + " "); }

            Console.Write("\nScramble:                        ");
            obj.toggleMode();
            tempArr = obj.scramble(randArr);
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nFilter Post Scramble (Large):    ");
            tempArr = obj.filter();
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }
        }

        // Prints out the results of calls to filter() and scramble(arr) for a dataCut child object, testing varying modes.
        static void printResultsDC(dataFilter obj)
        {
            int[] tempArr;
            int[] randArr;
            Random rand = new Random();

            Console.Write("\nFilter (Large):                  ");
            tempArr = obj.filter();
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nFilter (Small):                  ");
            obj.toggleMode();
            tempArr = obj.filter();
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nSequence passed into scramble 1: ");
            randArr = new int[defRandArrSize];
            for (int i = 0; i < defRandArrSize; i++) { randArr[i] = rand.Next(5, 95); Console.Write(randArr[i] + " "); }

            Console.Write("\nScramble (First call):           ");
            tempArr = obj.scramble(randArr);
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nSequence passed into scramble 2: ");
            randArr = new int[defRandArrSize];
            for (int i = 0; i < defRandArrSize; i++) { randArr[i] = rand.Next(5, 95); Console.Write(randArr[i] + " "); }

            Console.Write("\nScramble (Second call):          ");
            tempArr = obj.scramble(randArr);
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nFilter Post Scramble (Small):    ");
            tempArr = obj.filter();
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nSequence passed into scramble 3: ");
            randArr = new int[defRandArrSize];
            for (int i = 0; i < defRandArrSize; i++) { randArr[i] = rand.Next(5, 95); Console.Write(randArr[i] + " "); }

            Console.Write("\nScramble (Third call):           ");
            tempArr = obj.scramble(randArr);
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }

            Console.Write("\nFilter Post Scramble (Large):    ");
            obj.toggleMode();
            tempArr = obj.filter();
            for (int j = 0; j < tempArr.Length; j++) { Console.Write(tempArr[j] + " "); }
        }

        static void Main()
        {
            dataFilter[] hDataFilterArr = new dataFilter[arraySize];
            for (int i = 0; i < hDataFilterArr.Length; i++) { hDataFilterArr[i] = getObject(i); }
            printWelcome();
            for (int i = 0; i < hDataFilterArr.Length; i++) {
                if (i % 3 == 0) {
                    Console.WriteLine("======= DATAFILTER OBJECT (Object " + (i+1) + ") =======");
                    printResultsDF(hDataFilterArr[i]);
                    Console.WriteLine("\n");
                } else if (i % 3 == 1) {
                    Console.WriteLine("======= DATAMOD OBJECT    (Object " + (i + 1) + ") =======");
                    printResultsDM(hDataFilterArr[i]);
                    Console.WriteLine("\n");
                } else {
                    Console.WriteLine("======= DATACUT OBJECT    (Object " + (i + 1) + ") =======");
                    printResultsDC(hDataFilterArr[i]);
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
