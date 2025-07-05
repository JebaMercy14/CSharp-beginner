using System;

class Program
{
    static Random random = new Random();

    static void Main()
    {
        Console.WriteLine("Would you like to play? (Y/N)");
        if (ShouldPlay())
        {
            PlayGame();
        }
    }

    static void PlayGame()
    {
        var play = true;

        while (play)
        {
            var target = random.Next(1, 7); // Random target between 1 and 6
            var roll = random.Next(1, 7); // Random roll between 1 and 6

            Console.WriteLine($"Roll a number greater than {target} to win!");
            Console.WriteLine($"You rolled a {roll}");
            Console.WriteLine(WinOrLose(roll, target));
            Console.WriteLine("\nPlay again? (Y/N)");

            play = ShouldPlay();
        }
    }

    static bool ShouldPlay()
    {
        var response = Console.ReadLine();
        return response != null && response.Trim().ToUpper() == "Y";
    }

    static string WinOrLose(int roll, int target)
    {
        return roll > target ? "You win!" : "You lose!";
    }
}
