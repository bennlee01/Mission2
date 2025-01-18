using System;

namespace DiceRollingSimulation
{
    // Class that handles the dice rolling simulator
    public class DiceRoller
    {
        // Simulates rolling two dice for a specified number of rolls
        public int[] SimulateRolls(int numberOfRolls)
        {
            int[] rollResults = new int[13]; // Array to store counts of sums (indices 0 and 1 unused)
            Random random = new Random();   // Random number generator for dice rolls

            for (int i = 0; i < numberOfRolls; i++)
            {
                // Roll 1 die and store the number
                int die1 = random.Next(1, 7); // Generates a random number between 1 and 6

                // Roll another die and store the number (another instance of the die object)
                int die2 = random.Next(1, 7); // Generates another random number between 1 and 6

                // Add the two numbers together to get the sum of the two dice
                int sum = die1 + die2;

                // Update the tally for this sum in the array
                rollResults[sum]++;
            }

            return rollResults; // Return the array containing the results
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Dice Rolling Simulator!"); // Welcome message

            // Ask the user for the number of times to roll the dice
            Console.Write("Enter the number of times to roll the dice: ");

            // Validate the input to ensure it's a positive integer
            if (!int.TryParse(Console.ReadLine(), out int numberOfRolls) || numberOfRolls <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer."); // Error message for invalid input
                return;
            }

            // Instantiate the DiceRoller class and simulate the rolls
            DiceRoller diceRoller = new DiceRoller();
            int[] rollResults = diceRoller.SimulateRolls(numberOfRolls); // Perform the dice rolls and get results

            // Generate and display the histogram
            Console.WriteLine("\nDice Roll Results Histogram:");
            for (int i = 2; i <= 12; i++)
            {
                // Calculate the percentage of rolls for each number
                double percentage = (rollResults[i] / (double)numberOfRolls) * 100;

                // Print the number (sum of the dice)
                Console.Write($"{i}: ");

                // Display the percentage using asterisks (*), where each * represents 1%
                for (int j = 0; j < (int)Math.Round(percentage); j++)
                {
                    Console.Write("*");
                }

                // Print the percentage for the sum (formatted to two decimal places)
                Console.WriteLine($" ({percentage:F2}%)");
            }

            // Thank-you message after simulation
            Console.WriteLine("\nThank you for using the Dice Rolling Simulator!");
        }
    }
}
