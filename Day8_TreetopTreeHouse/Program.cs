using AoCHelpers;
//Clean this mess...

var input = InputHelper.ReadInputLinesFromFile("./input.txt").Select(x => x.Select(y => (int)char.GetNumericValue(y)).ToArray()).ToArray();

var treeVisibility = new byte[input.Length, input[0].Length];
var treeVisibilityRange = new int[input.Length, input[0].Length, 4];

var eastStepList = new List<int>();
var westStepList = new List<int>();

//Find the highest tree, and calculate how many trees each tree can see from east to west.
for (int y = 0; y < input.Length; y++)
{
    var row = input[y];
    var rightMax = 0;
    var leftMax = 0;

    int previousRight = 0;
    int previousLeft = 0;
    westStepList.Clear();
    eastStepList.Clear();

    for (int x = 0; x < row.Length; x++)
    {
        if (row[x] > leftMax)
        {
            treeVisibility[y, x] |= 0b1000;
            treeVisibilityRange[y, x, 0] = x;
            leftMax = row[x];
        } else if (row[x] > previousLeft)
        {
            var t = westStepList.AsEnumerable().Reverse().TakeWhile(z => row[z] < row[x]).LastOrDefault();
            treeVisibilityRange[y, x, 0] = (x - t) + 1;
            westStepList.Add(x);
        }
        else
        {
            treeVisibilityRange[y, x, 0] = 1;
        }

        if (row[x] != previousLeft || x == 0)
            westStepList.Add(x);

        previousLeft = row[x];

        var rIndex = row.Length - (x + 1);
        if (row[rIndex] > rightMax)
        {
            treeVisibilityRange[y, rIndex, 3] = x;
            treeVisibility[y, rIndex] |= 0b0001;
            rightMax = row[rIndex];
        } else if (row[rIndex] > previousRight)
        {
            var t = eastStepList.AsEnumerable().Reverse().TakeWhile(z => row[z] < row[rIndex]).LastOrDefault();
            treeVisibilityRange[y, rIndex, 3] = (t - rIndex) + 1;
        }
        else
        {
            treeVisibilityRange[y, rIndex, 3] = 1;
        }

        if (row[rIndex] != previousRight || x == 0)
            eastStepList.Add(rIndex);

        previousRight = row[rIndex];
    }
}

var northStepList = new List<int>();
var southStepList = new List<int>();
//Find the highest tree, and calculate how many trees each tree can see from north to south.
for (int x = 0; x < input[0].Length; x++)
{
    var tMax = 0;
    var bMax = 0;

    int previousUp = 0;
    int previousDown = 0;

    northStepList.Clear();
    southStepList.Clear();

    for (int y = 0; y < input.Length; y++)
    {
        if (input[y][x] > tMax)
        {
            treeVisibilityRange[y, x, 1] = y;
            treeVisibility[y, x] |= 0b0100;
            tMax = input[y][x];
        } else if (input[y][x] > previousUp)
        {
            var t = northStepList.AsEnumerable().Reverse().TakeWhile(z => input[z][x] < input[y][x]).LastOrDefault();
            treeVisibilityRange[y, x, 1] = (y - t) + 1;
        } else
        {
            treeVisibilityRange[y, x, 1] = 1;
        }

        if (y == 0 || input[y][x] != previousUp)
            northStepList.Add(y);

        previousUp = input[y][x];

        var bIndex = input.Length - (y + 1);

        if (input[bIndex][x] > bMax)
        {
            treeVisibility[bIndex, x] |= 0b0010;
            treeVisibilityRange[bIndex, x, 2] = y;
            bMax = input[bIndex][x];
        }
        else if (input[bIndex][x] > previousDown)
        {
            var t = southStepList.AsEnumerable().Reverse().TakeWhile(z => input[z][x] < input[bIndex][x]).LastOrDefault();
            treeVisibilityRange[bIndex, x, 2] = (t - bIndex) + 1;
        } else
        {
            treeVisibilityRange[bIndex, x, 2] = 1;
        }

        if (y == 0 || input[bIndex][x] != previousDown)
            southStepList.Add(bIndex);

        previousDown = input[bIndex][x];
    }
}

int count = 0;
for(int y = 0; y < input.Length; y++)
{
    for (int x = 0; x < input[y].Length; x++)
    {
        if (treeVisibility[y, x] != 0) { count++; }
    }
}

int scenicScore = 0;

for (int y = 0; y < input.Length; y++)
{
    for (int x = 0; x < input[y].Length; x++)
    {
        scenicScore = Math.Max(scenicScore,
            treeVisibilityRange[y, x, 0]
            * treeVisibilityRange[y, x, 1]
            * treeVisibilityRange[y, x, 2]
            * treeVisibilityRange[y, x, 3]
            );
    }
}

;
