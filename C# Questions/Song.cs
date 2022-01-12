/*
A playlist is considered a repeating playlist if any of the songs contain a reference to a previous song in the playlist. Otherwise, the playlist will end with the last song which points to null.

Implement a function IsRepeatingPlaylist that, efficiently with respect to time used, returns true if a playlist is repeating or false if it is not.

For example, the following code prints "True" as both songs point to each other.

Song first = new Song("Hello");
Song second = new Song("Eye of the tiger");
    
first.NextSong = second;
second.NextSong = first;

Console.WriteLine(first.IsRepeatingPlaylist());
 */

using System;

public class Song
{
    private string name;
    public Song NextSong { get; set; }

    public Song(string name)
    {
        this.name = name;
    }

    public bool IsRepeatingPlaylist()
    {
        Song fast = this;
        Song slow = this;
        while (fast != null && fast.NextSong != null)
        {
            fast = fast.NextSong.NextSong;
            slow = slow.NextSong;
            if (fast == slow)
                return true;
        }
        return false;
    }
    public static void Main(string[] args)
    {
        Song first = new Song("Hello");
        Song second = new Song("Eye of the tiger");

        first.NextSong = second;
        second.NextSong = first;

        Console.WriteLine(first.IsRepeatingPlaylist());
    }
}
