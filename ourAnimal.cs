using System;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[,] ourAnimals = new string[4, 6]
            {
                { "d1", "dog", "2", "lola", "medium sized cream colored female golden retriever weighing about 65 pounds. housebroken.", "loves to have her belly rubbed and likes to chase her tail. gives lots of kisses." },
                { "d2", "dog", "9", "loki", "large reddish-brown male golden retriever weighing about 85 pounds. housebroken.", "loves to have his ears rubbed when he greets you at the door, or at any time! loves to lean-in and give doggy hugs." },
                { "c3", "cat", "1", "Puss", "small white female weighing about 8 pounds. litter box trained.", "friendly" },
                { "c4", "cat", "?", "", "", "" }
            };

            // Outer loop to iterate through the animals
            for (int i = 0; i < ourAnimals.GetLength(0); i++)
            {
                // Check for existing pet data
                if (!string.IsNullOrEmpty(ourAnimals[i, 0]))
                {
                    Console.WriteLine($"ID #: {ourAnimals[i, 0]}");
                    Console.WriteLine($"Species: {ourAnimals[i, 1]}");
                    Console.WriteLine($"Age: {ourAnimals[i, 2]}");
                    Console.WriteLine($"Nickname: {ourAnimals[i, 3]}");
                    Console.WriteLine($"Physical description: {ourAnimals[i, 4]}");
                    Console.WriteLine($"Personality: {ourAnimals[i, 5]}");
                    Console.WriteLine(); // Add a blank line for better readability
                }
            }

            Console.WriteLine("Press the Enter key to continue.");
            Console.ReadLine();
        }
    }
}
