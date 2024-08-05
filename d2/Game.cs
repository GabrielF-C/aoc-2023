using System.Diagnostics;
using System.Text;


namespace AOC2023.d2
{
    using Cubes = Dictionary<Color, int>;

    internal class Game(int id)
    {
        public List<Cubes> Sets { get; } = [];
        public int Id { get; } = id;

        public Cubes GetMinimumSet()
        {
            Cubes minSet = [];
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                minSet.Add(color, GetMaxForColor(color));
            }
            return minSet;
        }

        public bool IsPossible(Cubes trueCubes)
        {
            bool isPossible = true;

            foreach (var trueCube in trueCubes)
            {
                if (GetMaxForColor(trueCube.Key) > trueCube.Value)
                {
                    isPossible = false;
                    break;
                }
            }

            return isPossible;
        }

        public static List<Game> GetPossible(List<Game> games, Cubes trueCubes)
        {
            List<Game> possibleGames = [];
            foreach (var game in games)
            {
                if (game.IsPossible(trueCubes))
                {
                    possibleGames.Add(game);
                }
            }
            return possibleGames;
        }

        public int GetMaxForColor(Color color)
        {
            return Sets.Aggregate(0, (max, cubes) =>
            {
                int n = cubes.GetValueOrDefault(color, 0);
                if (n > max)
                {
                    max = n;
                }
                return max;
            });
        }

        public int GetMaxTotal()
        {
            int sum = 0;
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                sum += GetMaxForColor(color);
            }
            return sum;
        }

        public int GetMaxSetSum()
        {
            return Sets.Aggregate(0, (max, cubes) =>
            {
                int sum = cubes.Select(c => c.Value).Sum();
                if (sum > max)
                {
                    max = sum;
                }
                return max;
            });
        }

        public override string ToString()
        {
            StringBuilder sb = new();

            sb.Append("Game ");
            sb.Append(Id);
            sb.AppendLine();
            for (int i = 0; i < Sets.Count; i++)
            {
                sb.Append("-> Set ");
                sb.Append(i);
                sb.AppendLine();

                sb.Append("----> ");
                foreach (var cubes in Sets[i])
                {
                    sb.Append(cubes.Value);
                    sb.Append(" ");
                    sb.Append(cubes.Key);
                    sb.Append(", ");
                }
                sb.AppendLine();
            }

            return sb.ToString();
        }
    }
}
