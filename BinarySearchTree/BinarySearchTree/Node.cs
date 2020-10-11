using System;
using System.Collections.Generic;
using System.Data;
using System.Net.NetworkInformation;

namespace BinarySearchTree
{
    public class Node
    {
        public int Number { get; set; }

        public Node LeftNode { get; set; }

        public Node RightNode { get; set; }

        public Node()
        {
            Number = 0;
        }

        public Node(int number)
        {
            Number = number;
        }

        public void AddNode(int number)
        {
            if (number < this.Number)
            {
                if (LeftNode == null)
                {
                    LeftNode = new Node(number);
                }
                else
                {
                    LeftNode.AddNode(number);
                }
            }
            // skip when number == Number
            else if (number > this.Number)
            {
                if (RightNode == null)
                {
                    RightNode = new Node(number);
                }
                else
                {
                    RightNode.AddNode(number);
                }
            }
        }

        public Node FindNode(int number)
        {
            switch (number.CompareTo(this.Number))
            {
                case -1: return LeftNode.FindNode(number);
                case 0: return this;
                case 1: return RightNode.FindNode(number);
                default: return null;
            }
        }

        public List<char> FindNodeMoves(int number, List<char> moves = null)
        {
            moves ??= new List<char>();
            switch (number.CompareTo(this.Number))
            {
                case -1:
                    moves.Add('l');
                    LeftNode.FindNodeMoves(number, moves);
                    break;
                case 1:
                    moves.Add('r');
                    RightNode.FindNodeMoves(number, moves);
                    break;
            }
            return moves;
        }

        public static Node BalanceNode(Node node)
        {
            List<int> orderedNums = InorderTraversalArray(node); // set values to orderedNums
            int midVal = orderedNums[orderedNums.Count / 2]; // take middle value
            List<char> moves = node.FindNodeMoves(midVal); // find moves to find how come to new root

            for (int i = moves.Count - 1; i > 0; i--)
            {
                Node tempNode = node;
                for (int j = 0; j < i - 1; j++)
                {
                    tempNode = (moves[j] == 'l') ? tempNode.LeftNode : tempNode.RightNode;
                }

                if (moves[i-1] == 'l')
                {
                    tempNode.LeftNode = (moves[i] == 'l') ?
                        Node.RotateRight(tempNode.LeftNode) : Node.RotateLeft(tempNode.LeftNode);
                }
                else
                {
                    tempNode.RightNode = (moves[i] == 'l') ?
                        Node.RotateRight(tempNode.RightNode) : Node.RotateLeft(tempNode.RightNode);
                }
            }

            if (moves.Count != 0)
            {
                node = (midVal < node.Number) ? Node.RotateRight(node) : Node.RotateLeft(node);
            }

            node.LeftNode = (node.LeftNode != null) ? Node.BalanceNode(node.LeftNode) : null;
            node.RightNode = (node.RightNode != null) ? Node.BalanceNode(node.RightNode) : null;

            return node;
        }

        // right rotation about p
        public static Node RotateRight(Node p) 
        {
            Node q = p.LeftNode;
            p.LeftNode = q.RightNode;
            q.RightNode = p;
            return q;
        }

        // left rotation about q
        public static Node RotateLeft(Node q) 
        {
            Node p = q.RightNode;
            q.RightNode = p.LeftNode;
            p.LeftNode = q;
            return p;
        }

        //Travesals
        public static void PreorderTraversal(Node startNode)
        {
            if (startNode == null)
            {
                return;
            }
            Console.Write($"{startNode.Number} ");
            PreorderTraversal(startNode.LeftNode);
            PreorderTraversal(startNode.RightNode);
        }

        public static void InorderTraversal(Node startNode)
        {
            if (startNode == null)
            {
                return;
            }
            InorderTraversal(startNode.LeftNode);
            Console.Write($"{startNode.Number} ");
            InorderTraversal(startNode.RightNode);
        }

        public static List<int> InorderTraversalArray(Node startNode, List<int> minimals = null, int maxSize = -1)
        {
            minimals ??= new List<int>();

            if (startNode == null)
            {
                return minimals;
            }

            if (maxSize > -1 && minimals.Count >= maxSize)
            {
                return minimals;
            }

            InorderTraversalArray(startNode.LeftNode, minimals);
            minimals.Add(startNode.Number);
            InorderTraversalArray(startNode.RightNode, minimals);

            return minimals;
        }

        public static void PostorderTraversal(Node startNode)
        {
            if (startNode == null)
            {
                return;
            }
            PostorderTraversal(startNode.LeftNode);
            PostorderTraversal(startNode.RightNode);
            Console.Write($"{startNode.Number} ");
        }
    }
}
