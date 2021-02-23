using System.Collections.Generic;
using System.Text;

namespace Turing.TuringMachine
{
    public class MachineLog
    {
        private readonly List<string> _log;

        public string TapeState;

        public MachineLog()
        {
            _log = new List<string>();
        }

        public void Clear() => _log.Clear();

        public void Dump(List<char> tape, int index)
        {
            var tapeStr = new string(tape.ToArray());
            tapeStr = tapeStr.Insert(index + 1, "<");
            tapeStr = tapeStr.Insert(index, ">");
            _log.Add(tapeStr);
        }

        public string GetLog()
        {
            var builder = new StringBuilder()
                .Append("Machine log: ")
                .Append("\n------\n");
            
            for (var i = 0; i < _log.Count; i++)
            {
                builder
                    .Append(i + 1)
                    .Append(". ")
                    .Append(_log[i])
                    .Append('\n');
            }
            
            builder.Append("------");
            return builder.ToString();
        }
    }
}