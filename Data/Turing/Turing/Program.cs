using System;
using Turing.TuringMachine;

namespace Turing
{
    public static class Program
    {
        public static void Main()
        {
            var tape = "aab";
            ShowSymbolReplacer(tape);

            tape = "(()[]([]))";
            ShowParenthesesChecker(tape);
        }

        private static void ShowSymbolReplacer(string input)
        {
            const string initial = "0";
            const string bAdder = "1";
            const string aReplacer = "2";

            var nodes = new[]
            {
                new Node(initial)
                    .Add('b', 'b', 1, initial)
                    .Add('a', 'a', -1, bAdder)
                    .Add('#', '#', 0, Machine.AnswerYes),

                new Node(bAdder)
                    .Add('b', 'b', -1, bAdder)
                    .Add('#', 'b', 0, aReplacer),

                new Node(aReplacer)
                    .Add('b', 'b', 1, aReplacer)
                    .Add('a', 'b', 0, initial)
            };

            var machine = new Machine(input, nodes);
            var perform = machine.Perform(initial, true);
            Console.WriteLine(machine.Log.ToString());
            Console.WriteLine($"Initial data: {input}");
            Console.WriteLine(perform);
        }

        private static void ShowParenthesesChecker(string input)
        {
            const string initial = "0";
            const string parenthesesOpen= "1";
            const string parenthesesClosed = "2";
            const string bracketsOpen = "3";
            const string bracketsClosed = "4";
            const string wayToInitial = "5";

            var nodes = new[]
            {
                new Node(initial)
                    .Add('-', '-', 1, initial)
                    .Add('(', '(', 1, parenthesesOpen)
                    .Add('[', '[', 1, bracketsOpen)
                    .Add(')', ')', 0, Machine.AnswerNo)
                    .Add(']', ']', 0, Machine.AnswerNo)
                    .Add('#', '#', 0, Machine.AnswerYes),
                
                new Node(parenthesesOpen)
                    .Add('-', '-', 1, parenthesesOpen)
                    .Add('(', '(', 1, parenthesesOpen)
                    .Add(')', '-', -1, parenthesesClosed)
                    .Add('[', '[', 1, bracketsOpen)
                    .Add(']', ']', 0, Machine.AnswerNo)
                    .Add('#', '#', 0, Machine.AnswerNo),
                
                new Node(parenthesesClosed)
                    .Add('-', '-', -1, parenthesesClosed)
                    .Add('(', '-', 0, wayToInitial),

                new Node(bracketsOpen)
                    .Add('-', '-', 1, bracketsOpen)
                    .Add('[', '[', 1, bracketsOpen)
                    .Add(']', '-', -1, bracketsClosed)
                    .Add('(', '(', 1, parenthesesOpen)
                    .Add(')', ')', 0, Machine.AnswerNo)
                    .Add('#', '#', 0, Machine.AnswerNo),
                
                new Node(bracketsClosed)
                    .Add('-', '-', -1, bracketsClosed)
                    .Add('[', '-', 0, wayToInitial),
                
                new Node(wayToInitial)
                    .Add('-','-',-1, wayToInitial)
                    .Add('(','(',-1, wayToInitial)
                    .Add(')',')',-1, wayToInitial)
                    .Add('[','[',-1, wayToInitial)
                    .Add(']',']',-1, wayToInitial)
                    .Add('#','#',1, initial)
            };

            var machine = new Machine(input, nodes);
            var perform = machine.Perform(initial, true);
            Console.WriteLine(machine.Log.ToString());
            Console.WriteLine($"Initial data: {input}");
            Console.WriteLine(perform);
        }
    }
}