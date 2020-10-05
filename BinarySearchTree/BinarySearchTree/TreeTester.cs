using System;

namespace BinarySearchTree
{
    class TreeTester
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.AddNode(1);
            tree.AddNode(2);
            tree.AddNode(6);
            tree.AddNode(7);
            tree.AddNode(4);
            tree.AddNode(10);

            TreePrinter.PrintChildNodes(tree.RootNode);
            Console.ReadKey();
            Console.Clear();

        }
    }
}
