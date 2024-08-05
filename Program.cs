using AOC2023.d1;
using AOC2023.d2;

internal class Program
{
    private static void Main(string[] args)
    {

    }

    private static void DayTwo()
    {
        DayTwoParser parser = new(@"data/day2.txt", false);
        var data = parser.Parse();

        // Part 1
        Dictionary<Color, int> trueCubes = new() {
            { Color.Red, 12 },
            { Color.Green, 13 },
            { Color.Blue, 14 },
        };
        Console.WriteLine(Game.GetPossible(data, trueCubes).Select(g => g.Id).Sum());

        // Part 2
        List<Dictionary<Color, int>> minSets = [];
        data.ForEach(g => minSets.Add(g.GetMinimumSet()));
        Console.WriteLine(
            minSets.Sum(
                (set) => set.Aggregate(1, (power, cube) => cube.Value * power)
            )
        );
    }

    private static void DayOne()
    {
        DayOneParser parser = new(@"data/day1.txt", false);
        var data = parser.Parse();
        Console.WriteLine(data.Sum());
    }
}