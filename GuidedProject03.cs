using System;
using System.Threading;

namespace TerminalGame
{
    class Program
    {
        static int windowWidth = Console.WindowWidth;
        static int windowHeight = Console.WindowHeight;
        static int playerX = windowWidth / 2;
        static int playerY = windowHeight / 2;
        static int foodX;
        static int foodY;
        static char[] states = { '@', '#', '$', '%', '&' };
        static char[] foods = { '*', '+', '-', '=', '!' };
        static char player = states[0];
        static char food;
        static bool freezePlayer = false;
        static int moveSpeed = 200; // Movement speed in milliseconds

        static void Main(string[] args)
        {
            SetupGame();
            while (true)
            {
                if (Console.WindowWidth != windowWidth || Console.WindowHeight != windowHeight)
                {
                    Console.Clear();
                    Console.WriteLine("Console was resized. Program exiting.");
                    break;
                }

                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Escape || !IsDirectionalKey(key))
                    {
                        Console.WriteLine("Exiting game.");
                        break;
                    }

                    MovePlayer(key);
                    if (playerX == foodX && playerY == foodY)
                    {
                        ConsumeFood();
                    }
                }

                Thread.Sleep(moveSpeed);
            }
        }

        static void SetupGame()
        {
            Console.Clear();
            DisplayFood();
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);
        }

        static void DisplayFood()
        {
            Random random = new Random();
            foodX = random.Next(0, windowWidth);
            foodY = random.Next(0, windowHeight);
            food = foods[random.Next(foods.Length)];
            Console.SetCursorPosition(foodX, foodY);
            Console.Write(food);
        }

        static void ConsumeFood()
        {
            player = food;
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);

            if (food == '!')
            {
                freezePlayer = true;
                Thread.Sleep(1000); // Freeze player for 1 second
                freezePlayer = false;
            }
            else if (food == '+')
            {
                moveSpeed = Math.Max(50, moveSpeed - 50); // Increase speed
            }

            DisplayFood();
        }

        static void MovePlayer(ConsoleKey key)
        {
            if (freezePlayer) return;

            Console.SetCursorPosition(playerX, playerY);
            Console.Write(' ');

            switch (key)
            {
                case ConsoleKey.UpArrow:
                    playerY = Math.Max(0, playerY - 1);
                    break;
                case ConsoleKey.DownArrow:
                    playerY = Math.Min(windowHeight - 1, playerY + 1);
                    break;
                case ConsoleKey.LeftArrow:
                    playerX = Math.Max(0, playerX - 1);
                    break;
                case ConsoleKey.RightArrow:
                    playerX = Math.Min(windowWidth - 1, playerX + 1);
                    break;
            }

            Console.SetCursorPosition(playerX, playerY);
            Console.Write(player);
        }

        static bool IsDirectionalKey(ConsoleKey key)
        {
            return key == ConsoleKey.UpArrow || key == ConsoleKey.DownArrow || key == ConsoleKey.LeftArrow || key == ConsoleKey.RightArrow;
        }
    }
}
