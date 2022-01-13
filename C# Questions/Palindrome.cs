/*
https://www.testdome.com/questions/c-sharp/palindrome/4951

Write a function that checks if a given sentence is a palindrome. A palindrome is a word, phrase, verse, or sentence that reads the same backward or forward. Only the order of English alphabet letters (A-Z and a-z) should be considered, other characters should be ignored.

For example, IsPalindrome("Noel sees Leon.") should return true as spaces, period, and case should be ignored resulting with "noelseesleon" which is a palindrome since it reads same backward and forward.
 */

using System;

public class Palindrome
{
    public static bool IsPalindrome(string str)
    {
 
        char[] chars = str.ToLower().ToCharArray();
        int lo = 0;
        int hi = chars.Length - 1;
        while(lo < hi)
        {
            while (hi>0 && !Char.IsLetter(chars[hi])) hi--;
            while (lo<hi && !Char.IsLetter(chars[lo])) lo++;

            if (chars[lo] != chars[hi] && Char.IsLetter(chars[hi]) && Char.IsLetter(chars[lo]))
                return false;
            lo++;
            hi--;
        }
        return true;
    }

    public static void Main(string[] args)
    {
        Console.WriteLine(IsPalindrome("Noel sees Leon."));
    }
}