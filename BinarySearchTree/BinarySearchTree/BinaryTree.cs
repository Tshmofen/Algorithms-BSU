using System.Collections.Generic;

namespace BinarySearchTree
{
    public class BinaryTree
    {
        public Node RootNode { get; set; }

        public BinaryTree()
        {
            RootNode = null;
        }

        public BinaryTree(int number)
        {
            RootNode = new Node(number);
        }

        public void AddNode(int number)
        {
            if (RootNode == null)
            {
                RootNode = new Node(number);
            }
            else
            {
                RootNode.AddNode(number);
            }
        }

        public void AddNode(Node node, Node startNode = null)
        {
            if (RootNode == null)
            {
                RootNode = node;
                return;
            }

            if (startNode == null)
            {
                startNode = RootNode;
            }

            if (node.Number < startNode.Number)
            {
                if (startNode.LeftNode == null)
                {
                    startNode.LeftNode = node;
                }
                else
                {
                    AddNode(node, startNode.LeftNode);
                }
            }
            // skip if number already here
            else if (node.Number > startNode.Number)
            {
                if (startNode.RightNode == null)
                {
                    startNode.RightNode = node;
                }
                else
                {
                    AddNode(node, startNode.RightNode);
                }
            }
        }

        public int FindMinimalNode(int k = 1)
        {
            return RootNode.FindMinimalNode(k);
        }

        public void PreorderTraversal()
        {
            Node.PreorderTraversal(this.RootNode);
        }

        public void InorderTraversal()
        {
            Node.InorderTraversal(this.RootNode);
        }

        public void PostorderTraversal()
        {
            Node.PostorderTraversal(this.RootNode);
        }

        public void BalanceTree()
        {
            RootNode = Node.BalanceNode(RootNode);
        }
    }
}
