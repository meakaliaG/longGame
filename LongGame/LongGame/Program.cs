using System;
using System.IO;


namespace LongGame
{
    internal class Program
    {
        static void Main()
        {
            //initiate username, filepath, score
            Console.WriteLine("Enter your name: ");
            string username = Console.ReadLine();
            string filepath = $"{username}.txt";

            int score = 0;

            //check if player file exists
            //if so - load file and update player score
            if (File.Exists(filepath))
            {
                string savedScore = File.ReadAllText(filepath);
                if (int.TryParse(savedScore, out int previousScore))
                {
                    score = previousScore;
                    Console.WriteLine($"Welcome back, {username}!");
                    Console.WriteLine($"Your previous score: {score}");
                }
                //cannot find file, you get nothing
                else
                {
                    Console.WriteLine("Could not find your previous file. Starting your score at 0.");
                }
            }
            //new player!
            else
            {
                Console.WriteLine($"Hello player {username}!");
                Console.WriteLine("Starting with a score of 0.");

            }
            Console.WriteLine("Hit any key to increase your score you animal! Press Enter to quit.");

            //collects key pressings
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey(intercept: true);

                if (keyInfo.Key == ConsoleKey.Enter)
                {
                    break;
                }

                //update score!!!
                score++;
                Console.WriteLine($"Score: {score}");
            }

            //save score to player name .txt file
            File.WriteAllText(filepath, score.ToString());
            Console.WriteLine($"Game over! Final score saved to {filepath}");


        }
            }
}
