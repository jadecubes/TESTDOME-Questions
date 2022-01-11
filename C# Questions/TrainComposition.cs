using System;
using System.Collections.Generic;
/*
 * 
A TrainComposition is built by attaching and detaching wagons from the left and the right sides, efficiently with respect to time used.

For example, if we start by attaching wagon 7 from the left followed by attaching wagon 13, again from the left, we get a composition of two wagons (13 and 7 from left to right). Now the first wagon that can be detached from the right is 7 and the first that can be detached from the left is 13.

Implement a TrainComposition that models this problem.
 *
 */
public class Wagon
{
    public Wagon nxt { get; set; }
    public Wagon pre { get; set; }
    public int id { get; set; }
    public Wagon(int id)
    {
        this.id = id;
    }
}
public class DLL
{
    Wagon head;
    Wagon tail;
    int size = 0;
    public DLL()
    {
        head = new Wagon(-1);
        tail = new Wagon(-1);
        head.nxt = tail;
        tail.pre = head;
    }
    public void addLast(Wagon n)
    {
        n.nxt = tail;
        n.pre = tail.pre;
        tail.pre.nxt = n;
        tail.pre = n;
        size++;
    }
    public void addFirst(Wagon n)
    {
        n.nxt = head.nxt;
        n.nxt.pre = n;
        n.pre = head;
        head.nxt = n;
        size++;
    }
    public void remove(Wagon n)
    {
        n.pre.nxt = n.nxt;
        n.nxt.pre = n.pre;
        size--;
    }
    public Wagon removeFirst()
    {
        if (head.nxt == tail)
            return null;
        Wagon res = head.nxt;
        remove(head.nxt);
        size--;
        return res;
    }
    public Wagon removeLast()
    {
        if (head.nxt == tail)
            return null;
        Wagon res = tail.pre;
        remove(res);
        size--;
        return res;
    }
    public int getSize()
    {
        return size;
    }
}
public class TrainComposition
{
    DLL train;
    public TrainComposition()
    {
        train = new DLL();
    }

    public void AttachWagonFromLeft(int wagonId)
    {
        train.addFirst(new Wagon(wagonId));
    }

    public void AttachWagonFromRight(int wagonId)
    {
        train.addLast(new Wagon(wagonId));
    }

    public int DetachWagonFromLeft()
    {
        Wagon w = train.removeFirst();
        if (w == null)
            return 0;
        return w.id;
    }

    public int DetachWagonFromRight()
    {
        Wagon w = train.removeLast();
        if (w == null)
            return 0;
        return w.id;
    }

    public static void Main(string[] args)
    {
        TrainComposition train = new TrainComposition();
        train.AttachWagonFromLeft(7);
        train.AttachWagonFromLeft(13);
    }
}