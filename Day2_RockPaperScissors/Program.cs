using AoCHelpers;

int[,] moveResultScoreLookup = new int[3, 3];
int[,] desiredOutcomeLookup = new int[3, 3];

for (int i = 0; i < 3; i++)
{
    var losingMoveIndex = GetLosingMoveIndex(i);
    var winningMoveIndex = GetWinningMoveIndex(i);

    moveResultScoreLookup[i, i] = 3;
    moveResultScoreLookup[i, winningMoveIndex] = 6;

    desiredOutcomeLookup[i, 0] = losingMoveIndex;
    desiredOutcomeLookup[i, 1] = i;
    desiredOutcomeLookup[i, 2] = winningMoveIndex;
}

var rounds = InputHelper.ReadInputLinesFromFile("./input.txt")
    .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(x => x.Single()));

var part1Results = rounds.Select(x => (OpponentMove: x.First() - 'A', OurMove: x.Last() - 'X'));
var part2Results = part1Results.Select(x => (x.OpponentMove, OurMove: desiredOutcomeLookup[x.OpponentMove, x.OurMove]));

Console.WriteLine($"Part 1: your total score was {SolveForTotalScore(part1Results)}");
Console.WriteLine($"Part 2: your total score was {SolveForTotalScore(part2Results)}");
Console.WriteLine("Press any key to exit...");
Console.ReadKey();

int SolveForTotalScore(IEnumerable<(int OpponentMove, int OurMove)> rounds)
{
    return rounds.Sum(x => moveResultScoreLookup[x.OpponentMove, x.OurMove] + x.OurMove + 1);
}

int GetWinningMoveIndex(int move) => move + 1 > 2 ? 0 : move + 1;
int GetLosingMoveIndex(int move) => move - 1 < 0 ? 2 : move - 1;