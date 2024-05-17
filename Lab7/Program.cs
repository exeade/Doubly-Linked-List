namespace Lab7;

public class Program
{
    static void Main(string[] args)
    {
        DLinkedList linkedList = new DLinkedList();
        linkedList.PushInBack(-6);
        linkedList.PushInBack(24);
        linkedList.PushInBack(62);
        linkedList.PushInBack(1);
        linkedList.PushInBack(19);
        linkedList.PushInBack(200);
        linkedList.PushInBack(31);
        linkedList.PushInBack(103);
        linkedList.PrintList();
        
        Console.WriteLine();
        int fMultiple = linkedList.GetMultipleOfFive();
        Console.WriteLine($"The first element that is a multiple of 5 is {linkedList[fMultiple].Data}.");
        Console.WriteLine();
        Console.WriteLine($"Sum of elements in even positions is {linkedList.SumOfEven()}");
        
        Console.WriteLine();
        DLinkedList greaterNodes = linkedList.CreateBiggerList(30);
        Console.WriteLine("Let's create a list with elements greater than 30.");
        greaterNodes.PrintList();
        
        Console.WriteLine();
        Console.WriteLine("Let's remove elements whose value is greater than the average in the list.");
        linkedList.DeleteGreaterThanAv();
        linkedList.PrintList();
    }
}