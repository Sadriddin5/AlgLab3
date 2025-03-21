using System;

public class Node
{
    public int Value { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public Node(int value)
    {
        Value = value;
    }
}

public class TreeCreator
{
    public static Node CreateSkewedTree(int n, int[] values)
    {
        if (n <= 0 || n % 2 != 0 || values.Length != n)
        {
            return null; // Обработка некорректных входных данных
        }

        Node root = new Node(values[0]);
        Node current = root;
        int index = 1;

        while (index < n)
        {
            current.Left = new Node(values[index]);
            index++;

            if (index < n)
            {
                current.Right = new Node(values[index]);
                current = current.Right;
                index++;
            }
        }

        return root;
    }

    public static void PrintTree(Node node, int level = 0)
    {
        if (node != null)
        {
            PrintTree(node.Right, level + 1);
            Console.WriteLine(new string(' ', level * 2) + node.Value);
            PrintTree(node.Left, level + 1);
        }
    }

    public static void Main(string[] args)
    {
        int n = 6;
        int[] values = { 1, 2, 3, 4, 5, 6 };

        Node root = CreateSkewedTree(n, values);

        if (root != null)
        {
            Console.WriteLine("Созданное дерево:");
            PrintTree(root);
        }
        else
        {
            Console.WriteLine("Ошибка: некорректные входные данные.");
        }
    }
}
