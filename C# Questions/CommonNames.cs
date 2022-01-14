/*
https://www.testdome.com/questions/c-sharp/common-names/20300
Implement the FindCommon method. When passed two arrays of names, it will return an array containing the names that appear in either or both arrays. The returned array should have no duplicates.

For example, calling Names.FindCommon(new string[]{'Ava', 'Emma', 'Olivia'}, new string[]{'Olivia', 'Sophia', 'Emma'}) should return an array containing Ava, Emma, Olivia, and Sophia in any order. 
 */

using System;
using System.Collections.Generic;
public class Names
{
    public static string[] FindCommon(string[] names1, string[] names2)
    {
        HashSet<String> result = new HashSet<String>();
        foreach (string name in names1)
            result.Add(name);
        foreach (string name in names2)
            result.Add(name);
        String[] ret=new String[result.Count];
        result.CopyTo(ret);
        return ret;
    }

    public static void Main(string[] args)
    {
        string[] names1 = new string[] { "Ava", "Emma", "Olivia" };
        string[] names2 = new string[] { "Olivia", "Sophia", "Emma" };
        Console.WriteLine(string.Join(", ", Names.FindCommon(names1, names2))); // should print Ava, Emma, Olivia, Sophia
    }
}