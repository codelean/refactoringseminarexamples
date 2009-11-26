using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArraySorting
{
    public enum SortType
    {
        BubbleSort = 0,
        SelectionSort = 1,
        InsertionSort = 2
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Input a list of numbers, separated by commas: ");
            string input = Console.ReadLine();

            Console.WriteLine("Enter a sort algorithm (Bubble Sort = 0, Selection Sort, Isertion Sort = 2)");
            SortType sortType = (SortType)Enum.Parse(typeof(SortType), Console.ReadLine());

            string[] items = input.Split(',');
            int[] intArray = new int[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                intArray[i] = int.Parse(items[i]);
            }

            int[] a = intArray;

            int j;
            int index;

            switch (sortType)
            {
                case SortType.SelectionSort:
                    for (int sortedSize = 0; sortedSize < a.Length; sortedSize++)
                    {
                        // find minimum of remaining unsorted list
                        int minElementIndex = sortedSize;
                        int minElementValue = a[sortedSize];
                        for (int i = sortedSize + 1; i < a.Length; i++)
                        {
                            if (a[i] < minElementValue)
                            {
                                minElementIndex = i;
                                minElementValue = a[i];
                            }
                        }

                        // swap a[sortedSize] with minimum
                        a[minElementIndex] = a[sortedSize];
                        a[sortedSize] = minElementValue;
                    }
                    break;

                case SortType.InsertionSort:

                    int numberOfElements = a.Length;
                    for (int i = 1; i < numberOfElements; i++)
                    {
                        index = a[i];
                        j = i;

                        while ((j > 0) && (a[j - 1] > index))
                        {
                            a[j] = a[j - 1];
                            j = j - 1;
                        }

                        a[j] = index;
                    }
                    break;

                case SortType.BubbleSort:
                    int[] array = intArray;
                    long rightBorder = array.Length - 1;

                    do
                    {
                        long lastExchange = 0;

                        for (long i = 0; i < rightBorder; i++)
                        {
                            if (array[i] > array[i + 1])
                            {
                                int temp = array[i];
                                array[i] = array[i + 1];
                                array[i + 1] = temp;

                                lastExchange = i;
                            }
                        }

                        rightBorder = lastExchange;
                    }
                    while (rightBorder > 0);
                    break;
            }

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.WriteLine(intArray[i]);
            }
        }
    }
}
