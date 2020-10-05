﻿using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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

        public bool DeleteNode(int number)
        {
            Node current = FindNode(number);
            Node parent = FindNodeParent(number);

            // there are no such element
            if (current == null)
            {
                return false;
            }

            // one child or less
            if (current.RightNode == null || current.LeftNode == null)
            {
                Node shiftNode  = (current.RightNode != null) ? current.RightNode : current.LeftNode;
                if (parent == null)
                {
                    RootNode = shiftNode;
                }
                else
                {
                    if (parent.LeftNode != null && parent.LeftNode.Number == current.Number)
                    {
                        parent.LeftNode = shiftNode;
                    }
                    else
                    {
                        parent.RightNode = shiftNode;
                    }
                }
            }

            // two childs
            if (current.RightNode != null && current.LeftNode != null)
            {
                if (parent == null)
                {
                    RootNode = current.RightNode;
                    AddNode(current.LeftNode);
                }
                else
                {
                    if (parent.LeftNode != null && parent.LeftNode.Number == current.Number)
                    {
                        parent.LeftNode = current.LeftNode;
                        AddNode(current.RightNode, parent.LeftNode);
                    }
                    if (parent.RightNode != null && parent.RightNode.Number == current.Number)
                    {
                        parent.RightNode = current.LeftNode;
                        AddNode(current.RightNode, parent.RightNode);
                    }
                }
            }

            return true;
        }

        private Node FindNodeParent(int number)
        {
            Node current = RootNode;
            Node parent = null;

            while (current != null)
            {
                if (current.Number > number)
                {
                    parent = current;
                    current = current.LeftNode;
                }
                else if (current.Number < number)
                {
                    parent = current;
                    current = current.RightNode;
                }
                else
                {
                    break;
                }
            }

            return parent;
        }

        public Node FindNode(int number)
        {
            return RootNode.FindNode(number);
        }

        public int FindMinimalNode(int k = 1)
        {
            List<int> numbers = new List<int>();
            InorderTraversalArray(RootNode, numbers);
            return numbers[k - 1];
        }

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

        public static void InorderTraversalArray(Node startNode, List<int> minimals)
        {
            if (startNode == null)
            {
                return;
            }
            InorderTraversalArray(startNode.LeftNode, minimals);
            minimals.Add(startNode.Number);
            InorderTraversalArray(startNode.RightNode, minimals);
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

        public BinaryTree CreateBalancedTree()
        {
            
        }

    }
}