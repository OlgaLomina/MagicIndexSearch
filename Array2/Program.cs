using System;

//A magic index in an array A[0…n - 1] is defined to be an index such that A[i] = i.
//Given a sorted array of distinct integers, write a method to find a magic index if one exists, in an array A.
//FOLLOW UP: What if the values are not distinct?

class Program
{
    static int MagicIndexSearch(int[] arr, int start, int end)
    {
        if (start <= end)
        {
            int middle = (start + end) / 2;
            if (middle == arr[middle])
                return middle;
            if (middle < arr[middle])
                return MagicIndexSearch(arr, start, middle - 1);
            else
                return MagicIndexSearch(arr, (middle + 1), end);
        }
        return -1;
    }

    static int MagicIndexFollowup(int[] arr, int start, int end)
    {
        if (start <= end)
        {
            int middle = (start + end) / 2;
            if (middle == arr[middle])
                return middle;
            //search in the left
            int leftEnd = Math.Min(middle - 1, arr[middle]);
            int leftIndex = MagicIndexFollowup(arr, start, leftEnd);
            if (leftIndex >= 0)
                return leftIndex;

            //search in the right
            int rightStart = Math.Max(middle + 1, arr[middle]);
            int rightIndex = MagicIndexFollowup(arr, rightStart, end);
            if (rightIndex >= 0)
                return rightIndex;

        }
        return -1;
    }


    public static void Main()
    {
        int[] arr = { -1, 0, 2, 3, 4, 4 };
        int n = arr.Length;
        //int index = MagicIndexSearch(arr, 0, n - 1);
        int index = MagicIndexFollowup(arr, 0, n - 1);
        if (index > 0)
            Console.Write("Magic Index is " + index + "            ");
        else
            Console.Write("Magic Index is not found    ");


    }
}