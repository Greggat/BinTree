using System;

namespace BinTree
{
    class Program
    {
        static void Main(string[] args)
        {
            var test = new BinaryTree<string>();
            test.Insert(5, "Five");
            test.Insert(6, "Six");
            test.Insert(4, "Four");
            test.Insert(3, "Three");
            test.Insert(1, "One");
            test.Insert(7, "Seven");
            test.Insert(9, "Nine");
            test.Insert(0, "Zero");
            test.Insert(11, "Eleven");
            Console.Write($"GetValue(0) = ");
            Console.Write(test[0]);
        }
    }
}
