using System.Runtime.CompilerServices;

namespace AOC2023.common
{
    internal abstract class Parser<T>(string fileName, bool debug = false)
    {
        private readonly string fileName = fileName;
        private readonly bool debug = debug;

        public List<T> Parse()
        {
            List<T> values = [];

            foreach (string line in File.ReadLines(fileName))
            {
                T val = ParseLine(line);
                values.Add(val);

                if (debug)
                {
                    Console.WriteLine();
                    Console.WriteLine(line);
                    Console.WriteLine("===============");
                    Console.WriteLine(val);
                }
            }

            return values;
        }

        protected abstract T ParseLine(string line);
    }
}
