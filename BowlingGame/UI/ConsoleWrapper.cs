using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.UI
{
    public interface IConsoleWrapper
    {
        List<string> ReadLines();
        void WriteLines(List<string> outputLines);
    }

    public class ConsoleWrapper : IConsoleWrapper
    {
        public List<string> ReadLines()
        {
            var input = new List<string>();

            string line;
            while (!string.IsNullOrEmpty(line = Console.ReadLine()))
            {
                input.Add(line);
            }

            return input;
        }

        public void WriteLines(List<string> outputLines)
        {
            outputLines.ForEach(Console.WriteLine);
        }
    }
}
