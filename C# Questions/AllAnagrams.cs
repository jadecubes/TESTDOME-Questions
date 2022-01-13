/*
https://www.testdome.com/questions/csharp/allanagrams/2984

An anagram is a word formed from another by rearranging its letters, using all the original letters exactly once; for example, orchestra can be rearranged into carthorse.

Write a function which returns all anagrams of a given word (including the word itself) in any order.

For example GetAllAnagrams("abba") should return collection containing "aabb", "abab", "abba", "baab", "baba", "bbaa".
 */

using System;
using System.Collections.Generic;

public class AllAnagrams
{
    public static ICollection<string> GetAllAnagrams(string str)
    {
        HashSet<String> set=new HashSet<string>();
        permuteStr(str.ToCharArray(), set, new List<Char>(), new bool[str.Length]);
        return set;
    }
    public static void permuteStr(char[] charAry, HashSet<String> set,List<Char> tmp,bool[] visited)
    {
        if (tmp.Count == charAry.Length)
        {
            string s = "";
            foreach(char c in tmp)
            {
                s += c;
            }
            set.Add(s);
            return;
        }

        for(int i = 0; i < charAry.Length; i++)
        {
            if (visited[i])
                continue;

            tmp.Add(charAry[i]);
            visited[i] = true;
            permuteStr(charAry, set, tmp, visited);
            visited[i] = false;
            tmp.RemoveAt(tmp.Count - 1);

        }
    }

    public static void Main(string[] args)
    {
        ICollection<string> anagrams = GetAllAnagrams("abc");
        foreach (string a in anagrams)
            Console.WriteLine(a);
    }
}