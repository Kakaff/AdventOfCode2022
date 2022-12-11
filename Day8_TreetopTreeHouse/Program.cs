using AoCHelpers;
using AoCHelpers.ArrayExtensions;
using AoCHelpers.IEnumerableExtensions;

//Well this got messier than i had hoped...
//Doing it all in one file sure doesn't help either
//But hey, we managed to do it without writing more than 2 for loops for the search!

var input = InputHelper.ReadInputLinesFromFile("./input.txt").Select(x => x.Select(y => (int)char.GetNumericValue(y)).ToArray()).ToArray();
var treeInfos = new TreeInfo[input.Length, input.Length].Fill(() => new TreeInfo());

SolvePuzzle();

Console.WriteLine($"Part 1: There are {treeInfos.Count(x => x.IsVisible)} visible trees");
Console.WriteLine($"Part 2: The most scenic tree has a score of {treeInfos.Max(x => x.ViewDistances.Aggregate(1, (acc,val) => acc *= val))}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

void SolvePuzzle()
{
    var stepLists = new List<(int y, int x)>[4].Fill(() => new List<(int y, int x)>());

    for (int y = 0; y < input!.Length; y++)
    {
        stepLists.ForEach(x => x.Clear());

        var highestTree = new int[4];
        var previousTreeHeight = new int[4];

        for (int x = 0; x < input.Length; x++)
        {
            ComputeTreeInfo(input, x, x, y, highestTree, previousTreeHeight, stepLists, Direction.West);
            ComputeTreeInfo(input, x, (input.Length - 1) - x, y, highestTree, previousTreeHeight, stepLists, Direction.East);

            ComputeTreeInfo(input, x, y, x, highestTree, previousTreeHeight, stepLists, Direction.North);
            ComputeTreeInfo(input, x, y, (input.Length - 1) - x, highestTree, previousTreeHeight, stepLists, Direction.South);
        }
    }
}

void ComputeTreeInfo(in int[][] treeMap, int iteration, in int x, in int y, int[] highestTree, int[] previousTreeHeight, List<(int, int)>[] stepList, Direction direction)
{
    TreeInfo tree = treeInfos[y, x];

    var (isVisible, viewDistance) = CheckTreeVisibilityAndViewDistance(treeMap, iteration, x, y, ref highestTree[(int)direction], ref previousTreeHeight[(int)direction], stepList[(int)direction]);
    tree.IsVisible |= isVisible;
    tree.ViewDistances[(int)direction] = viewDistance;
}

(bool IsVisible, int viewDistance) CheckTreeVisibilityAndViewDistance(in int[][] treeMap, int iteration, in int x, in int y, ref int maxHeight, ref int previousHeight, List<(int y, int x)> stepList)
{
    var viewDistance = 0;
    var isVisible = false;

    var currentTreeHeight = treeMap[y][x];

    if (currentTreeHeight > maxHeight)
    {
        isVisible = true;
        viewDistance = iteration; //We can't simply set it to x since we also do reverse searches.
        maxHeight = currentTreeHeight;
    }
    else if (currentTreeHeight > previousHeight)
    {
        viewDistance = CalculateTreeViewDistance(treeMap, x, y, stepList);
    }
    else
    {
        viewDistance = 1;
    }

    if (currentTreeHeight != previousHeight || iteration == 0)
        stepList.Add((y, x));

    previousHeight = currentTreeHeight;

    return (isVisible, viewDistance);
}

int CalculateTreeViewDistance(int[][] treeMap, int x, int y, List<(int y, int x)> stepList)
{
    var step = stepList.AsEnumerable().Reverse().TakeWhile(previousStep => treeMap[previousStep.y][previousStep.x] < treeMap[y][x]).LastOrDefault();
    var min = 0;
    var max = 0;

    var otherTreeHeight = treeMap[step.y][step.x];

    if (step.y == y)
    {
        min = Math.Min(step.x, x);
        max = Math.Max(step.x, x);
    }
    else
    {
        min = Math.Min(step.y, y);
        max = Math.Max(step.y, y);
    }

    return (max - min) + 1;
}

enum Direction
{
    North, East, South, West
}

record class TreeInfo(int Height, bool IsVisible, int[] ViewDistances)
{
    public bool IsVisible { get; set; } = IsVisible;
    public TreeInfo() : this(0, false, new int[4]) { }
}
