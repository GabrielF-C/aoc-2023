using AOC2023.common;
using AOC2023.d2;

namespace AOC2023.d2
{
    internal class DayTwoParser(string fileName, bool debug = false) : Parser<Game>(fileName, debug)
    {
        protected override Game ParseLine(string line)
        {
            string[] parts = line.Split(": ");

            int id = Convert.ToInt32(parts[0].Split(' ')[1]);
            Game game = new(id);

            string[] sets = parts[1].Split("; ");
            for (int i = 0; i < sets.Length; i++)
            {
                game.Sets.Add([]);

                foreach (string cube in sets[i].Split(", "))
                {
                    string[] cubeParts = cube.Split(' ');
                    game.Sets[i].Add(
                        Enum.Parse<Color>(cubeParts[1], true),
                        Convert.ToInt32(cubeParts[0])
                    );
                }
            }

            return game;
        }
    }
}