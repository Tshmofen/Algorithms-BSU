using System.Collections.Generic;

namespace Turing.TuringMachine
{
    public class Node
    {
        private readonly Dictionary<char, Behaviour> _behaviour;

        public string Name { get; }

        public Node(string name)
        {
            _behaviour = new Dictionary<char, Behaviour>();
            Name = name;
        }
        
        public Node Add(char found, char replacer, int action, string nextNode)
        {
            _behaviour.Add(found, new Behaviour(replacer, action, nextNode));
            return this;
        }
        public Behaviour GetBehaviour(char found) => _behaviour[found];
    }
}