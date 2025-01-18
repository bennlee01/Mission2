using System;

namespace DiceRollingSimulation
{
    // Class that handles the dice rolling simulator
    public class DiceRoller
    {
        public int[] SimulateRolls(int numberOfRolls)
        {
            int[] rollResults = new int[13]; // Indices 0 and 1 are unused for simplicity
            Random random = new Random();

            for (int i = 0; i < numberOfRolls; i++)
            {
                int die1 = random.Next(1, 7); // Roll first die (1 to 6)
                int die2 = random.Next(1, 7); // Roll second die (1 to 6)
                int sum = die1 + die2;       // Calculate the sum
                rollResults[sum]++;          // Increment the count for the sum
            }

            return rollResults;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dice Rolling Simulator!");
            Console.Write("Enter the number of times to roll the dice: ");

            if (!int.TryParse(Console.ReadLine(), out int numberOfRolls) || numberOfRolls <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
                return;
            }

            // Instantiate the DiceRoller class and simulate rolls
            DiceRoller diceRoller = new DiceRoller();
            int[] rollResults = diceRoller.SimulateRolls(numberOfRolls);

            // Generate and display the histogram
            Console.WriteLine("\nDice Roll Results Histogram:");
            for (int i = 2; i <= 12; i++)
            {
                double percentage = (rollResults[i] / (double)numberOfRolls) * 100;
                Console.Write($"{i}: ");
                for (int j = 0; j < (int)Math.Round(percentage); j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine($" ({percentage:F2}%)");
            }

            Console.WriteLine("\nThank you for using the Dice Rolling Simulator!"); // Thank you message
        }
    }
}
