using System;

int fieldSize = int.Parse(Console.ReadLine());
string[,] field = new string[fieldSize, fieldSize];
string carNumber = Console.ReadLine();

int[] fPosition = new int[2] { -1, -1 };
int[] t1Position = new int[2] { -1, -1 };
int[] t2Position = new int[2] { -1, -1 };

int[] carPosition = new int[2] { 0, 0 };


int totalDistance = 0;

for (int row = 0; row < fieldSize; row++)
{
    string[] colValues = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

    for (int col = 0; col < fieldSize; col++)
    {
        field[row, col] = colValues[col];

        if (field[row, col] == "F")
        {
            fPosition[0] = row;
            fPosition[1] = col;
        }

        if (field[row, col] == "T")
        {
            if (t1Position[0] == -1)
            {
                t1Position[0] = row;
                t1Position[1] = col;
            }
            else
            {
                t2Position[0] = row;
                t2Position[1] = col;
            }
        }
    }
}

string input = string.Empty;
field[carPosition[0], carPosition[1]] = "C";
bool isDNS = true;

while ((input = Console.ReadLine()) != "End")
{
    field[carPosition[0], carPosition[1]] = ".";

    switch (input)
    {
        case "left":
            carPosition[1]--;
            break;
        case "right":
            carPosition[1]++;
            break;
        case "up":
            carPosition[0]--;
            break;
        case "down":
            carPosition[0]++;
            break;
    }

    if (field[carPosition[0], carPosition[1]] == ".")
    {
        totalDistance += 10;
        field[carPosition[0], carPosition[1]] = "C";
    }
    else if (field[carPosition[0], carPosition[1]] == "T")
    {
        totalDistance += 30;
        field[carPosition[0], carPosition[1]] = ".";
        if (carPosition[0] == t1Position[0] & carPosition[1] == t1Position[1])
        {
            carPosition[0] = t2Position[0];
            carPosition[1] = t2Position[1];
            field[carPosition[0], carPosition[1]] = "C";
        }
        else
        {
            carPosition[0] = t1Position[0];
            carPosition[1] = t1Position[1];
            field[carPosition[0], carPosition[1]] = "C";
        }
    }
    else if (field[carPosition[0], carPosition[1]] == "F")
    {
        totalDistance += 10;
        field[carPosition[0], carPosition[1]] = "C";
        isDNS = false;
        break;
    }
}

if (isDNS)
{
    Console.WriteLine($"Racing car {carNumber} DNF.");
}
else
{
    Console.WriteLine($"Racing car {carNumber} finished the stage!");
}

Console.WriteLine($"Distance covered {totalDistance} km.");

for (int row = 0; row < fieldSize; row++)
{
    for (int col = 0; col < fieldSize; col++)
    {
        Console.Write(field[row,col]);
    }
    Console.WriteLine();
}