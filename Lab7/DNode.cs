namespace Lab7;

public class DNode
{
    public long Data { get; set; }
    public DNode? Next { get; set; }
    public DNode? Prev { get; set; }
        
    public DNode(long data)
    {
        Data = data;
    }

    public DNode(long data, DNode? next, DNode? prev) : this(data)
    {
        Next = next;
        Prev = prev;
    }
}