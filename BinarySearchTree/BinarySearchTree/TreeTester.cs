using System;

namespace BinarySearchTree
{
    public class TreeTester
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            int[] nodes = { 1, 2, 9, 6, 7, 4, 10 };
            foreach (int num in nodes) tree.AddNode(num);

            TreePrinter.PrintChildNodes(tree.RootNode);
            Console.ReadKey();
            Console.Clear();

            tree.BalanceTree();

            TreePrinter.PrintChildNodes(tree.RootNode);
            Console.ReadKey();
            Console.Clear();

        }
    }
}
