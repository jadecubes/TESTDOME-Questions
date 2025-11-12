# 🎯 TESTDOME Questions & Solutions

**A curated collection of efficient, well-documented solutions to TestDome coding challenges in C#**

![C#](https://img.shields.io/badge/C%23-239120?style=flat&logo=c-sharp&logoColor=white)
![Problems Solved](https://img.shields.io/badge/problems-15-brightgreen)
![License](https://img.shields.io/badge/license-MIT-blue)

---

## 🤔 Why This Repository?

TestDome provides real-world coding assessments used by companies for technical screening. This repository demonstrates:

- **Clean, readable solutions** that prioritize clarity and maintainability
- **Optimal time complexity** implementations using appropriate data structures
- **Production-ready code** with proper error handling and edge case coverage
- **Learning-focused** comments explaining problem constraints and approach

***

## 📚 Problem Categories

### Data Structures & Algorithms
| Problem | Difficulty | Topics | Time Complexity |
|---------|-----------|--------|-----------------|
| [Binary Search Tree](C#%20Questions/BST.cs) | ⭐⭐ | Trees, Recursion | O(log n) |
| [Two Sum](C#%20Questions/TwoSum.cs) | ⭐⭐ | Hash Tables, Arrays | O(n) |
| [Sorted Search](C#%20Questions/SortedSearch.cs) | ⭐⭐ | Binary Search | O(log n) |
| [Train Composition](C#%20Questions/TrainComposition.cs) | ⭐⭐ | Stacks, Deque | O(1) operations |
| [Frog](C#%20Questions/Frog.cs) | ⭐⭐ | Dynamic Programming | O(n) |

### String Manipulation
| Problem | Difficulty | Topics | Time Complexity |
|---------|-----------|--------|-----------------|
| [Palindrome](C#%20Questions/Palindrome.cs) | ⭐ | String Processing | O(n) |
| [Are Anagrams](C#%20Questions/AreAnagrams.cs) | ⭐⭐ | String, Hash Maps | O(n) |
| [All Anagrams](C#%20Questions/AllAnagrams.cs) | ⭐⭐⭐ | String, Grouping | O(n * k log k) |

### Collections & LINQ
| Problem | Difficulty | Topics | Time Complexity |
|---------|-----------|--------|-----------------|
| [Merge Names](C#%20Questions/MergeNames.cs) | ⭐ | LINQ, Sets | O(n) |
| [Common Names](C#%20Questions/CommonNames.cs) | ⭐ | LINQ, Intersection | O(n + m) |
| [Song](C#%20Questions/Song.cs) | ⭐⭐ | Linked Lists | O(n) |

### Object-Oriented Design
| Problem | Difficulty | Topics | Time Complexity |
|---------|-----------|--------|-----------------|
| [Account](C#%20Questions/Account.cs) | ⭐⭐ | OOP, Encapsulation | - |
| [Folder](C#%20Questions/Folder.cs) | ⭐⭐ | Composite Pattern | O(n) |
| [Path](C#%20Questions/Path.cs) | ⭐⭐ | String Parsing | O(n) |
| [Route Planner](C#%20Questions/RoutePlanner.cs) | ⭐⭐⭐ | Graph Traversal, BFS | O(V + E) |

***

## 🚀 Getting Started

### Prerequisites
- .NET SDK 6.0 or higher
- Any C# IDE (Visual Studio, Rider, VS Code)

### Running Solutions Locally

Each file is self-contained with a `Main` method for easy testing:

```bash
# Navigate to the C# Questions directory
cd "C# Questions"

# Compile and run any solution
dotnet run BST.cs

# Or use the C# compiler directly
csc BST.cs && ./BST.exe
```

***

## 💡 Featured Solutions

### Two Sum - Efficient Hash Table Approach

**Problem**: Find two indices whose values sum to a target.

```csharp
public static Tuple<int, int> FindTwoSum(IList<int> list, int sum)
{
    Dictionary<int,int> map = new Dictionary<int, int>();
    for (int i = 0; i < list.Count; i++)
    {
        int target = sum - list[i];
        if (map.ContainsKey(target))
            return new Tuple<int, int>(i, map[target]);
        map[list[i]] = i;
    }
    return null;
}
```

**Key Insight**: Single-pass solution using hash table to store complements. Time: O(n), Space: O(n).

---

### Binary Search Tree - Leveraging BST Properties

**Problem**: Efficiently check if a BST contains a value.

```csharp
public static bool Contains(Node root, int value)
{
    if (root == null) return false;
    if (root.Value == value)
        return true;
    else if (root.Value < value)
        return Contains(root.Right, value);
    else if (root.Value > value)
        return Contains(root.Left, value);
    else
        return false;
}
```

**Key Insight**: Exploits BST ordering property to achieve O(log n) average case vs O(n) for unordered tree traversal.

***

## 🎓 Learning Path

**Beginner** (Start here if new to algorithms)
1. Palindrome
2. Merge Names
3. Common Names

**Intermediate** (Build on fundamentals)
4. Two Sum
5. Binary Search Tree
6. Are Anagrams
7. Sorted Search

**Advanced** (Graph algorithms & optimization)
8. Route Planner
9. All Anagrams
10. Frog (Dynamic Programming)

***

## 📊 Solution Statistics

- **Average Time Complexity**: O(n) or better for 87% of solutions
- **Space Optimization**: In-place algorithms used where possible
- **Code Quality**: All solutions tested against TestDome's test suites
- **Documentation**: Every solution includes problem description and constraints

***

## 🛠️ Project Structure

```
TESTDOME-Questions/
├── C# Questions/          # All C# solution files
│   ├── BST.cs            # Self-contained with problem statement
│   ├── TwoSum.cs         # Each file has Main method for testing
│   └── ...
└── README.md             # This file
```

***

## 🔗 Resources

- **TestDome Platform**: [https://www.testdome.com/questions](https://www.testdome.com/questions)
- **C# Documentation**: [Microsoft Docs](https://docs.microsoft.com/en-us/dotnet/csharp/)
- **Algorithm Complexity Reference**: [Big-O Cheat Sheet](https://www.bigocheatsheet.com/)

***

## 🤝 Contributing

Found a more efficient solution or want to add problems in other languages? Contributions are welcome!

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/python-solutions`)
3. Include problem description as comments
4. Add test cases in `Main` method
5. Submit a pull request

***

## 📝 License

This project is licensed under the MIT License - see individual files for problem copyrights held by TestDome.

***

## ⚠️ Disclaimer

These solutions are provided for **educational purposes**. If you're taking a TestDome assessment:
- Understand the logic, don't copy blindly
- Companies value problem-solving process over memorized solutions
- Use this as a learning resource to improve your skills

***

**Happy Coding!** 🚀

*Built with ☕ and algorithms*
