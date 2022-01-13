/*
https://www.testdome.com/questions/csharp/areanagrams/483

An anagram is a word formed from another by rearranging its letters, using all the original letters exactly once; for example, orchestra can be rearranged into carthorse. Write a function that checks if two words are each other's anagrams.

For example, AreStringsAnagrams("momdad", "dadmom") should return true as arguments are anagrams.
 */
using System;

public class AreAnagrams
{
    public static bool AreStringsAnagrams(string a, string b)
    {
        char[] s1 = a.ToCharArray();
        char[] s2=b.ToCharArray();
        Array.Sort(s1);
        Array.Sort(s2);
        return new String(s1).Equals(new String(s2));
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(AreStringsAnagrams("momdad", "dadmom"));
    }
}