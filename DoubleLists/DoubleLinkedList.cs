using Shared;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace DoubleLists;

public class DoubleLinkedList<T> : ILinkedList<T> where T : IComparable<T>
{
    private Node<T>? _head;
    private Node<T>? _tail;

    public DoubleLinkedList()
    {
        _head = null;
        _tail = null;
    }

    public void Add(T data)
    {
        Node<T> start = new Node<T>(data);
        if (_head == null) { _head = _tail = start; return; }

        if (data.CompareTo(_head.Data) <= 0)
        {
            start.Next = _head;
            _head.Previous = start;
            _head = start;
            return;
        }

        Node<T> current = _head;
        while (current.Next != null && current.Next.Data.CompareTo(data) < 0)
            current = current.Next;

        start.Next = current.Next;
        if (current.Next != null)
            current.Next.Previous = start;
        else
            _tail = start;

        current.Next = start;
        start.Previous = current;
    }

    public void showForward(T data)
    {
        Node<T>? current = _head;
        while (current != null)
        {
            Console.Write($"[ {current.Data} ] ");
            current = current.Next;
        }
        Console.WriteLine();
        return;
    }

    public void showBack(T data)
    {
        Node<T>? current = _tail;

        if (current == null)
        {
            Console.WriteLine("The list is empty.");
            return;
        }
        while (current != null)
        {
            Console.Write($"[ {current.Data} ] ");
            current = current.Previous;
        }
        Console.WriteLine();
    }

    public void orderDecently(T data)
    {
        Node<T>? current = _head;
        Node<T>? temp = null;

        while (current != null)
        {
            temp = current.Previous;
            current.Previous = current.Next;
            current.Next = temp;
            current = current.Previous;
        }

        if (temp != null)
        {
            _tail = _head;
            _head = temp.Previous;
        }

        Console.WriteLine("\n--- Inverted list ---");
        Node<T>? printNode = _head;
        while (printNode != null)
        {
            Console.Write($"[ {printNode.Data} ] ");
            if (printNode.Next != null) Console.Write("<-> ");
            printNode = printNode.Next;
        }
    }

    public void showFashions(T data)
    {
        if (_head == null) return;
        var count = getFrequencies();
        int max = count.Values.Max();
        var fashion = count.Where(x => x.Value == max).Select(x => x.Key);
        Console.WriteLine("Fashions: " + string.Join(", ", fashion));
    }

    private Dictionary<T, int> getFrequencies()
    {
        var dic = new Dictionary<T, int>();
        Node<T>? aux = _head;
        while (aux != null)
        {
            if (dic.ContainsKey(aux.Data!)) dic[aux.Data!]++; else dic[aux.Data!] = 1;
            aux = aux.Next;
        }
        return dic;
    }

    public void showGraph(T data)
    {
        var count = getFrequencies();

        Console.WriteLine("\n--- Frequency histogram---");

        foreach (var pair in count)
        {
            string label = pair.Key.ToString();

            string barrita = new string('*', pair.Value);

            Console.WriteLine($"{label.PadRight(15)}  {barrita}");
        }
        return;
    }

    public void exists(T data)
    {
        Node<T>? current = _head;
        while (current != null)
        {
            if (current.Data.CompareTo(data) == 0) { Console.WriteLine($"If there is the {data}"); return; }
            current = current.Next;
        }
        Console.WriteLine($"There is no {data}");
        return;
    }

    public void eliminate(T data, bool all)
    {
        Node<T>? corrunt = _head;
        while (corrunt != null)
        {
            if (corrunt.Data.CompareTo(data) == 0)
            {
                if (corrunt == _head) { _head = corrunt.Next; if (_head != null) _head.Previous = null; else _tail = null; }
                else if (corrunt == _tail) { _tail = corrunt.Previous; _tail.Next = null; }
                else { corrunt.Previous.Next = corrunt.Next; corrunt.Next.Previous = corrunt.Previous; }

                if (!all) return;
            }
            corrunt = corrunt.Next;
        }
    }

    override public string ToString()
    {
        var current = _head;
        var result = string.Empty;
        while (current != null)
        {
            result += $"{current.Data} -> ";
            current = current.Next;
        }
        result += "null";
        return result;
    }
}