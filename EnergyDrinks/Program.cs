using System;
using System.Collections.Generic;
using System.Linq;

Stack<int> caffeinMilligram = new Stack<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));
Queue<int> energyDrinks = new Queue<int>(Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));

const int maxCaffein = 300;

int totalStamatCaffein = 0;

while (caffeinMilligram.Count > 0 && energyDrinks.Count > 0 )
{
    if (caffeinMilligram.Peek() * energyDrinks.Peek() <= maxCaffein - totalStamatCaffein)
    {
        totalStamatCaffein += (caffeinMilligram.Pop() * energyDrinks.Dequeue());
    }
    else
    {
        if (totalStamatCaffein > 30)
        {
            totalStamatCaffein -= 30;
        }
        else
        {
            totalStamatCaffein = 0;
        }

        caffeinMilligram.Pop();
        energyDrinks.Enqueue(energyDrinks.Dequeue());
    }
}

if (energyDrinks.Count > 0)
{
    Console.WriteLine($"Drinks left: {string.Join(", ", energyDrinks)}");
}
else
{
    Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
}

Console.WriteLine($"Stamat is going to sleep with {totalStamatCaffein} mg caffeine.");