/*
https://www.testdome.com/questions/c-sharp/friends/658

Given a data structure representing a social network, write a function that finds friends of a certain degree. Friends of the first degree are a member's immediate friends, friends of the second degree are friends of a member's friends excluding first degree friends, etc.

For example, if A is a friend with B and B is a friend with C, then GetFriendsOfDegree(A, 2) should return C since C is the only second degree friend of A (B is a first degree friend of A).
 */

using System;
using System.Collections.Generic;

public class Member
{
    public string Email { get; private set; }
    public bool visiting { get; private set; }
    public bool visited { get; private set; }
    public ICollection<Member> Friends { get; private set; }

    public Member(string email) : this(email, new List<Member>())//https://stackoverflow.com/questions/4009013/call-one-constructor-from-another/4009032
    {
    }

    public Member(string email, ICollection<Member> friends)
    {
        this.Email = email;
        this.Friends = friends;
    }

    public void AddFriends(ICollection<Member> friends)
    {
        foreach (Member friend in friends)
            this.Friends.Add(friend);
    }

    public void AddFriend(Member friend)
    {
        this.Friends.Add(friend);
    }

}

public class Friends
{
    //DFS is too complicated when we handle loops in this case / graph
    public static List<Member> GetFriendsOfDegree(Member member, int degree)
    {       
        Queue<Member> queue=new Queue<Member>();
        HashSet<Member> visited=new HashSet<Member> ();
        List<Member> result=new List<Member>();

        queue.Enqueue(member);
        
        while (degree>1)
        {
            int cnt = queue.Count;
            for (int i = 0; i < cnt; i++)
            {
                Member cur = queue.Dequeue();
                visited.Add(cur);
                foreach (Member nxt in cur.Friends)
                {
                    if (visited.Contains(nxt))
                        continue;
                    else
                    {
                      queue.Enqueue(nxt);
                    }
                }

            }
            degree--;
        }
        if (degree == 1)
        {
            int cnt = queue.Count;
            for (int i = 0; i < cnt; i++)
            {
                Member cur=queue.Dequeue();
                visited.Add(cur);
                foreach (Member nxt in cur.Friends)
                {
                    if (visited.Contains(nxt))
                        continue;
                    visited.Add(nxt);
                    //avoid adding repetitive values
                    result.Add(nxt);
                }
            }
            return result;
        }

        return result;
    }


    public static void Main(string[] args)
    {
        Member a = new Member("A");
        Member b = new Member("B");
        Member c = new Member("C");

        a.AddFriend(b);
        b.AddFriend(c);

        foreach (Member friend in GetFriendsOfDegree(a, 2))
            Console.WriteLine(friend.Email);
    }
}
