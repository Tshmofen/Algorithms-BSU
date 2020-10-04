using System;

namespace BinarySearchTree
{
    class TreeTester
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            tree.AddNode(7);
            tree.AddNode(3);
            tree.AddNode(3);
            tree.AddNode(8);
            tree.AddNode(9);
            tree.AddNode(4);
            tree.AddNode(1);
            tree.AddNode(2);
            tree.AddNode(15);
            tree.AddNode(18);

            TreePrinter.PrintChildNodes(tree.RootNode);
            Console.ReadKey();
            Console.Clear();

            tree.DeleteNode(18);

            TreePrinter.PrintChildNodes(tree.RootNode);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
