namespace BinarySearchTree
{
    public class Node
    {
        public int Number { get; set; }

        public Node LeftNode { get; set; }

        public Node RightNode { get; set; }

        public Node(int number)
        {
            Number = number;
        }

        public void AddNode(int number)
        {
            if (number < Number)
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
            else if (number > Number)
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
            switch (number.CompareTo(Number))
            {
                case -1: return LeftNode.FindNode(number);
                case 0: return this;
                case 1: return RightNode.FindNode(number);
                default: return null;
            }
        }
    }
}
