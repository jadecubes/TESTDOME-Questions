/*
Implement function CountNumbers that accepts a sorted array of unique integers and, efficiently with respect to time used, counts the number of array elements that are less than the parameter lessThan.

For example, SortedSearch.CountNumbers(new int[] { 1, 3, 5, 7 }, 4) should return 2 because there are two array elements less than 4. 
 */

using System;

public class SortedSearch
{
    public static int CountNumbers(int[] sortedArray, int lessThan)
    {
        int left = 0;
        int right = sortedArray.Length - 1;
        int floor = -1;
        while (left <= right)
        {
            int mid = (left + right) / 2;
            if(sortedArray[mid]== lessThan)
            {
                while(mid >= 0 && sortedArray[mid] == lessThan ) 
                    mid--;
                if (mid == -1) return 0;
                else return mid + 1;
            }
            if (sortedArray[mid] > lessThan)
                right = mid- 1;
            else
            {
                left = mid + 1;
                floor = mid; //ref: https://www.techiedelight.com/find-floor-ceil-number-sorted-array/
            }
        }
        if (floor == -1)
            return -1;
        else
            return floor + 1;
    }
    public static void Main(string[] args)
    {
        Console.WriteLine(SortedSearch.CountNumbers(new int[] { 1, 3,4, 5, 6,7 }, 4));
    }
}