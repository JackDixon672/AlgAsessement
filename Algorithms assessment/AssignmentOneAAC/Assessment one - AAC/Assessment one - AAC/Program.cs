using System;
using System.Collections.Generic;
using System.IO;

namespace Assessment_one___AAC
{
    class Program
    {
        static List<string> mergeList = new List<string>();
        static List<string> arrayOptions = new List<string>() { "Net_1_256.txt", "Net_2_256.txt", "Net_3_256.txt", "Net_1_2048.txt", "Net_2_2048.txt", "Net_3_2048.txt" };
        static string[] numberArray;
        static bool reverse;

        static void Main(string[] args)
        {
            ArrayOptions();
            Numbers numList = new Numbers(numberArray, numberArray.Length, reverse);
            SortingOptions(numList);

            //Displaying the sorted array
            Console.WriteLine("Would you like to view the array? OPTIONS: (Y/N)");
            if (Console.ReadLine() == "Y") displayArray(numList);

            SearchingOptions(numList);
        }  
        
        static void ArrayOptions()
        {
            //Selecting ascending or descending
            Console.WriteLine("Select whether you would like to sort in ascending or descending order OPTIONS: (a/d)");
            reverse = (Console.ReadLine() == "d");

            //Selecting if the use would like to merge multipl arrays together
            Console.WriteLine("Would you like to merge multiple arrays together? OPTIONS: (Y/N)");
            bool merge = (Console.ReadLine() == "Y");
            switch (merge)
            {
                case (true):
                    bool mergeComplete;
                    do
                    {
                        Console.WriteLine("Select which array you would like to analyse \n1 netOne256\n2 netTwo256\n3 netThree256\n4 netOne2048\n5 netTwo2048\n6 netThree2048");
                        int selectedArray = int.Parse(Console.ReadLine()) - 1;
                        mergeList.AddRange(File.ReadAllLines(arrayOptions[selectedArray]));

                        Console.WriteLine("Would you like to add more arrays to be merged? (Y/N)");
                        mergeComplete = (Console.ReadLine() == "Y");
                    } while (mergeComplete != false);

                    numberArray = mergeList.ToArray();
                    break;

                case (false):
                    //Selecting the array to be sorted
                    Console.WriteLine("Select which array you would like to analyse \n 1 netOne256\n 2 netTwo256\n 3 netThree256\n 4 netOne2048\n 5 netTwo2048\n 6 netThree2048");
                    numberArray = File.ReadAllLines(arrayOptions[int.Parse(Console.ReadLine()) - 1]);
                    break;
            }

        }

        static void SortingOptions(Numbers numList)
        {
            //Selecting which sorting algorithm to use
            Console.WriteLine("Please choose the sorting algorithm you would like to use on the array: \n1 Bubble Sort\n2 Quick Sort\n3 Insertion Sort\n4 Merge Sort");
            string chosenAlgorithm = Console.ReadLine();

            switch (chosenAlgorithm)
            {
                case ("1"):
                    Console.WriteLine("Bubble sort was chosen");
                    numList.bubbleSort();
                    break;
                case ("2"):
                    Console.WriteLine("Quick sort was chosen");
                    numList.quickSort();
                    break;
                case ("3"):
                    Console.WriteLine("Insertion sort was chosen");
                    numList.insertionSort();
                    break;
                case ("4"):
                    Console.WriteLine("Merge sort was chosen");
                    numList.mergeSortStarter();
                    break;
            }

            Console.WriteLine($"The array was sorted in {numList.count} operations");
        }

        static void SearchingOptions(Numbers numList)
        {
            Console.WriteLine("Enter a value to search for:");
            int searchItem = int.Parse(Console.ReadLine());

            Console.WriteLine("Select which searching algorithm is to be used \n 1 Binary Search\n 2 Fibonacci Search");
            int chosenAlgorithm = int.Parse(Console.ReadLine());
            int itemLocation = -2;
            switch (chosenAlgorithm)
            {
                case (1):
                    itemLocation = numList.binarySearch(numList.numbersArray, searchItem, 0, numList.numbersArray.Length-1, reverse);
                    break;
                case (2):
                    itemLocation = numList.fibonacciSearch(numList.numbersArray, searchItem, reverse);
                    break;
            }
            if (itemLocation >= 0) Console.WriteLine($"The item was found in location: {itemLocation}"); else Console.WriteLine($"The item was not found. The nearest value was {numList.numbersArray[(-itemLocation)-1]} at location {(-itemLocation)-1}");
            
        }

        static void displayArray(Numbers numList)
        {
            int displayInterval;
            if (numList.numbersArray.Length < 2048) displayInterval = 10; else displayInterval = 50;
            for (int x = 0; x <= numList.numbersArray.Length; x += displayInterval) Console.WriteLine(numList.numbersArray[x]);
        }
    }
}
