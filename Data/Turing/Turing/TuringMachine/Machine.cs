using System.Collections.Generic;

namespace Turing.TuringMachine
{
    public class Machine
    {
        public const string AnswerYes = "%final_answer_yes%";
        public const string AnswerNo = "%final_answer_no%";

        private readonly List<char> _tape;
        private readonly Dictionary<string, Node> _nodes;
        
        public MachineLog Log { get; }
        
        public Machine(string tape, Node[] nodes)
        {
            _tape = new List<char>(tape.ToCharArray());
            _nodes = new Dictionary<string, Node>();
            Log = new MachineLog();
            foreach (var node in nodes)
                _nodes.Add(node.Name, node);
        }

        public bool Perform(string initialNode, bool createLog)
        {
            if (createLog) Log.Clear();

            var currentSymbol = 0;
            var currentNode = initialNode;
            
            while (currentNode != AnswerYes && currentNode != AnswerNo)
            {
                if (createLog) Log.Dump(_tape, currentSymbol);

                var node = _nodes[currentNode];
                var behaviour = node.GetBehaviour(_tape[currentSymbol]);
                
                _tape[currentSymbol] = behaviour.Replacer;
                currentSymbol += behaviour.Move;
                currentNode = behaviour.NextNode;

                if (currentSymbol < 0)
                {
                    _tape.Insert(0, '#');
                    currentSymbol = 0;
                }
                if (currentSymbol == _tape.Count)
                {
                    _tape.Add('#');
                    currentSymbol = _tape.Count - 1;
                }
            }

            if (createLog) Log.TapeState = new string(_tape.ToArray());

            return currentNode == AnswerYes;
        }
    }
}