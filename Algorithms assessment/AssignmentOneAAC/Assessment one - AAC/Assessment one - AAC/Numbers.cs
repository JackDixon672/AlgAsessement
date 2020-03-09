using System;
using System.Collections.Generic;
using System.Text;

namespace Assessment_one___AAC
{
    class Numbers : Searching
    {
        public int count { get; set; }
        public int[] numbersArray { get; set; }        
        public int arrayLength { get; set; }
        public bool reverse { get; set; }
       
        public Numbers(string[] array, int arrayLen, bool reverseOrder)
        {
            arrayLength = arrayLen;
            reverse = reverseOrder;
            count = 0;

            numbersArray = new int[arrayLength]; //Defining the length of 'numbersArray'
            for(int x = 0; x < arrayLength; x++) numbersArray[x] = int.Parse(array[x]); //Cycle through all index locations, and store them as ints
        }

        public void bubbleSort()
        {
            for(int x = arrayLength - 1; x >= 0; x--) for(int y = 0; y < x; y++)
                if((numbersArray[y] > numbersArray[y+1] && !reverse) || (numbersArray[y] < numbersArray[y + 1] && reverse))
                    { 
                        swap(y, y+1);
                        count++;
                    }                                              
        }

        public void quickSort(int leftPointer = 0, int rightPointer = -1)
        {
            if(rightPointer == -1) rightPointer = arrayLength-1; //Setting the right pointer to n-1 in the first recursion of the method
            int x, y, pivot;

            pivot = numbersArray[(leftPointer + rightPointer) / 2];
            x = leftPointer;
            y = rightPointer;
            do
            {
                //The following while loops cycle through the code, stopping once a number that is on the wrong side of the pivot is found
                while (((numbersArray[x] < pivot && !reverse) || (numbersArray[x] > pivot && reverse)) && x < rightPointer) x++;
                while (((numbersArray[y] > pivot && !reverse) || (numbersArray[y] < pivot && reverse)) && y > leftPointer) y--;
                count++;
                if (x <= y)
                {
                    swap(x, y);
                    x++;
                    y--;
                }
            } while (x <= y);

            //Recursively calling the method if appropriate, with the appropriate pointers
            if (leftPointer < y) quickSort(leftPointer, y);
            if (rightPointer > x) quickSort(x, rightPointer);
        }

        public void insertionSort()
        {
            int amountSorted = 1; //Insertion sort considers the first item to be sorted
            int x;
            while (amountSorted < arrayLength)
            {
                int temp = numbersArray[amountSorted];
                for (x = amountSorted; x > 0; x--)
                    count++;
                    if ((temp < numbersArray[x - 1] && !reverse) || (temp > numbersArray[x - 1] && reverse))
                        numbersArray[x] = numbersArray[x - 1];
                    else
                        break;
                numbersArray[x] = temp;
                amountSorted++;
            }
        }

        public void mergeSortStarter()
        {
            int[] temp = new int[arrayLength];
            mergeSort(numbersArray, temp, 0, arrayLength-1);
        }

        public void mergeSort(int[] array, int[] temp, int leftPointer, int rightPointer)
        {
            int n = rightPointer - leftPointer + 1;
            int middle = leftPointer + n / 2;
            int i;
            count++;
            if (n < 2) return;
            for (i = leftPointer; i < middle; i++) { }
                temp[i] = array[i];

            mergeSort(temp, array, leftPointer, middle - 1);
            mergeSort(array, temp, middle, rightPointer);

            mergeHelper(array, temp, leftPointer, middle, rightPointer);
        }

        public void mergeHelper(int[] array, int[] temp, int leftPointer, int middle, int rightPointer)
        {
            int resultLocation = leftPointer;
            int tempLocation = leftPointer;
            int destinationLocation = middle;

            while (tempLocation < middle && destinationLocation <= rightPointer)
                if ((array[destinationLocation] < temp[tempLocation] && !reverse) || (array[destinationLocation] > temp[tempLocation] && reverse))
                    array[resultLocation++] = array[destinationLocation++];
                else
                    array[resultLocation++] = temp[tempLocation++];

            while (tempLocation < middle)
                array[resultLocation++] = temp[tempLocation++];
        }

        public void swap(int itemX, int itemY)
        {
            int temp = numbersArray[itemX];
            numbersArray[itemX] = numbersArray[itemY];
            numbersArray[itemY] = temp;
        }
        
    }
}
