/*
https://www.testdome.com/questions/c-sharp/frog/660
A frog only moves forward, but it can move in steps 1 inch long or in jumps 2 inches long. A frog can cover the same distance using different combinations of steps and jumps. Write a function that calculates the number of different combinations a frog can use to cover a given distance.

For example, a distance of 3 inches can be covered in three ways: step-step-step, step-jump, and jump-step.
 */

using System;
using System.Collections.Generic;

public class Frog
{
    public static int NumberOfWays(int n)
    {
        if (n == 0) return 0;
        if(n == 1) return 1;
        if (n == 2) return 2;
        return dfs(n,new Dictionary<int, int>());
    }
    public static int dfs(int n,Dictionary<int,int> map)
    {
        if (n == 0) return 0;
        if (n == 1) return 1;
        if (n == 2) return 2;
        if (map.ContainsKey(n)) return map[n];
        int cnt=dfs(n - 1, map) + dfs(n - 2, map);
        map[n]=cnt;
        return cnt;
    }

    public static void Main(String[] args)
    {
        Console.WriteLine(NumberOfWays(3));
    }
}