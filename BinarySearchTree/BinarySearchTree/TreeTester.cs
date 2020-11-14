using System;

namespace BinarySearchTree
{
    public class TreeTester
    {
        static void Main(string[] args)
        {
            BinaryTree tree = new BinaryTree();
            int[] nodes = { 1, 12, 13, 2, 9, 6, 8, 4, 15 };
            foreach (int num in nodes) tree.AddNode(num);

            // Tree building
            TreePrinter.PrintChildNodes(tree.RootNode);
            Console.ReadKey();
            Console.Write('\b');

            // Traversals
            Console.Write("Traversals:\n1)Preorder { ");
            tree.PreorderTraversal();
            Console.Write("}\n2)Inorder { ");
            tree.InorderTraversal();
            Console.Write("}\n3)Postorder { ");
            tree.PostorderTraversal();
            Console.WriteLine("}\n");

            Console.ReadKey();
            Console.Write("\b");

            // K-min element
            Console.Write("Finding of k-min element:\nEnter k = ");
            int k = 0;
            for(int i = 0; i < 1; i++)
            {
                try
                {
                    k = int.Parse(Console.ReadLine());
                    if (k < 1 || k > nodes.Length) throw new Exception();
                }
                catch(Exception)
                {
                    Console.Write("k = ");
                    i--;
                }
            }
            Console.WriteLine($"{k}-min element is {tree.FindMinimalNode(k)}\n");
            Console.ReadKey();
            Console.Write("\b");

            // Tree balancing
            Console.WriteLine("Original tree balanced by rotations:");
            tree.BalanceTree();

            TreePrinter.PrintChildNodes(tree.RootNode);
            Console.ReadKey();

        }
    }
}
