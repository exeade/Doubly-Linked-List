using System.Collections;

namespace Lab7;

public class DLinkedList: IEnumerable<DNode>
{
    private DNode? _head;
    private DNode? _tail;
    public int Size { get; private set; }

    public DLinkedList()
    {
        _head = null;
        _tail = null;
        Size = 0;
    }

    private bool IsEmpty()
    {
        return Size == 0;
    }
        
    public DNode this[int idx]
    {
        get
        {
            if (idx < 0 || idx >= Size)
            {
                throw new ArgumentOutOfRangeException(nameof(idx));
            }
                
            if (idx < Size / 2)
            {
                DNode? current = _head;
                for (int i = 0; i < idx; i++)
                {
                    current = current?.Next;
                }

                if (current == null)
                {
                    throw new NullReferenceException();
                }
                    
                return current;
            }
            else
            {
                DNode? current = _tail;
                for (int i = Size - 1; i > idx; i--)
                {
                    current = current?.Prev;
                }
                    
                if (current == null)
                {
                    throw new NullReferenceException();
                }
                    
                return current;
            }
        }
    }

    public void PushInBack(long value)
    {
        DNode nodeToPush = new DNode(value);
        if (IsEmpty())
        {
            _head = _tail = nodeToPush;
        }
        else
        {
            nodeToPush.Prev = _tail;
            nodeToPush.Next = null;
            if (_tail != null)
            {
                _tail.Next = nodeToPush;
                _tail = nodeToPush;
            }
        }
        Size++;
    }

    private void DeleteDNode(DNode nodeToDel)
    {
        if (nodeToDel.Prev == null && nodeToDel.Next == null)
        {
            throw new NullReferenceException();
        }
        if (nodeToDel.Prev == null)
        {
            _head = nodeToDel.Next;
            if (_head != null)
            {
                _head.Prev = null;
            }
                
        } 
        else if (nodeToDel.Next == null)
        {
            _tail = nodeToDel.Prev;
            if (_tail != null)
            {
                _tail.Next = null;
            }
        }
        else
        {
            DNode? prevNode = nodeToDel.Prev;
            DNode? nextNode = nodeToDel.Next;
            if ( prevNode != null && nextNode != null)
            {
                prevNode.Next = nextNode;
                nextNode.Prev = prevNode;
            }
        }

        Size--;
    }

    public int GetMultipleOfFive()
    {
        for (int i = 0; i < Size; i++)
        {
            if (this[i].Data % 5 == 0)
            {
                return i;
            }
        }
        Console.WriteLine("No element multiple of 5 was found in the list");
        return -1;
    }

    public long SumOfEven()
    {
        long sum = 0;
        for (int i = 0; i < Size; i++)
        {
            if (i % 2 == 0)
            {
                sum += this[i].Data;
            }
        }

        return sum;
    }

    public DLinkedList CreateBiggerList(long value)
    {
        DLinkedList newList = new DLinkedList();
        foreach (DNode node in this)
        {
            if (node.Data > value)
            {
                newList.PushInBack(node.Data);
            }
        }

        return newList;
    }

    public void DeleteGreaterThanAv()
    {
        if (IsEmpty())
        {
            return;
        }
        long totalSum = 0;
        foreach (DNode node in this)
        {
            totalSum += node.Data;
        }

        long averageValue = totalSum / Size;
        Console.WriteLine($"Average value is {averageValue}.");
        foreach (DNode node in this)
        {
            if (node.Data > averageValue)
            {
                DeleteDNode(node);
            }
        }
    }

    public void PrintList()
    {
        Console.WriteLine("The doubly linked list:");
        foreach (DNode node in this)
        {
            Console.Write(node.Data + " ");
        }
        Console.WriteLine();
    }
        
    public IEnumerator<DNode> GetEnumerator()
    {
        return new DNodesEnumerator(this);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}