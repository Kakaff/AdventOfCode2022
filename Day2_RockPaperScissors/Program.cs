string inputText;

using (var file = File.OpenRead("./input.txt"))
using (var streamReader = new StreamReader(file))
    inputText = streamReader.ReadToEnd();

int[,] moveLookup = new int[3, 3];
int[,] desiredOutComeLookup = new int[3, 3];

for (int i = 0; i < 3; i++)
{
    moveLookup[i, GetLosingMoveIndex(i)] = 0;
    moveLookup[i, i] = 3;
    moveLookup[i, GetWinningMoveIndex(i)] = 6;
}


for (int i = 0; i < 3; i++)
{
    desiredOutComeLookup[i, 0] = GetLosingMoveIndex(i);
    desiredOutComeLookup[i, 1] = i;
    desiredOutComeLookup[i, 2] = GetWinningMoveIndex(i);
}

FigureOutScoreForPart1(inputText);
FigureOutScoreForPart2(inputText);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();

IEnumerable<IEnumerable<char>> ParseRounds(string input)
{
    return input.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries)
    .Select(x => x.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(y => y.First()));
}

void FigureOutScoreForPart1(string input)
{
    var rounds = ParseRounds(input)
        .Select(x => (OpponentMove: x.First() - 'A', OurMove: x.Last() - 'X'));

    Console.WriteLine($"Part 1: your totalt score was {SolveForTotalScore(rounds)}");
}

void FigureOutScoreForPart2(string input)
{
    var rounds = ParseRounds(input)
        .Select(x => (OpponentMove: x.First() - 'A', DesiredOutCome: x.Last() - 'X'))
        .Select(x => (x.OpponentMove, OurMove: desiredOutComeLookup[x.OpponentMove, x.DesiredOutCome]));

    Console.WriteLine($"Part 2: your totalt score was {SolveForTotalScore(rounds)}");
}

int SolveForTotalScore(IEnumerable<(int OpponentMove, int OurMove)> rounds)
{
    return rounds.Sum(x => moveLookup[x.OpponentMove, x.OurMove] + x.OurMove + 1);
}

int GetWinningMoveIndex(int move) => move + 1 > 2 ? 0 : move + 1;
int GetLosingMoveIndex(int move) => move - 1 < 0 ? 2 : move - 1;