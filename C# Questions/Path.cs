/*
https://www.testdome.com/questions/csharp/path/3035
Write a function that provides change directory (cd) function for an abstract file system.

Notes:

Root path is '/'.
Path separator is '/'.
Parent directory is addressable as "..".
Directory names consist only of English alphabet letters (A-Z and a-z).
For example, new Path("/a/b/c/d").Cd("../x").CurrentPath should return "/a/b/c/x".

Note: The evaluation environment uses '\' as the path separator.
 */

using System;
using System.Text;
public class Path
{
    public string CurrentPath { get; private set; }

    public Path(string path)
    {
        this.CurrentPath = path;
    }

    public Path Cd(string newPath)
    {
        if (newPath.StartsWith("/"))
        {
            CurrentPath = newPath;

        }
        else
        {

            while (newPath.Contains(".."))
            {
                CurrentPath = goUpOneLevel(CurrentPath);
                newPath = goDownOneLevel(newPath);
            }
            if (newPath.Length > 0)
                CurrentPath += "/" + newPath;
        }
        return new Path(CurrentPath);
    }
    public string goUpOneLevel(string path)
    {
        //preprocess
        if (path[path.Length - 1] == '/')
            path = path.Substring(0, path.Length - 1);
        int lastIdx = path.LastIndexOf('/');
        if (lastIdx <= 0) return path;
        return path.Substring(0, lastIdx);

    }
    public string goDownOneLevel(string path)
    {
        //preprocess
        if (path[path.Length - 1] == '/')
            path = path.Substring(0, path.Length - 1);
        int lastIdx = path.IndexOf('/');
        if (lastIdx <= 0) return "";//case only ..
        return path.Substring(lastIdx + 1);
    }

    public static void Main(string[] args)
    {
        Path path = new Path("/a/b/c/d");
        Console.WriteLine(path.Cd("../x").CurrentPath);
    }
}