namespace Turing.TuringMachine
{
    public readonly struct Behaviour
    {
        public char Replacer { get; }
        public int Move { get; }
        public string NextNode { get; }

        public Behaviour(char replacer, int move, string nextNode)
        {
            Replacer = replacer;
            Move = move;
            NextNode = nextNode;
        }
    }
}