using System;

namespace BowlingGame2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rollScores = new int[21];
            int currentRoll = 0;
            string rollScoreString = "";
            int rollScoreInt = 0;
            int totalScore = 0;

            Console.WriteLine("Welcome to Bowling!");

            for (int frame = 1; frame <= 10; frame++)
            {
                Console.WriteLine("**************************");
                Console.WriteLine("Frame #" + frame);
                Console.WriteLine("**************************");
                rollScores[currentRoll] = Bowl();
                while(rollScores[currentRoll]>10 || rollScores[currentRoll] < 0)
                {
                    Console.WriteLine("Invalid Input!!!");
                    rollScores[currentRoll] = Bowl();
                }
                switch (frame)
                {
                    case 10:
                        currentRoll++;
                        rollScores[currentRoll] = Bowl();
                        if (rollScores[currentRoll] + rollScores[currentRoll - 1] == 10 || rollScores[currentRoll] == 10)
                        {
                            currentRoll++;
                            rollScores[currentRoll] = Bowl();
                        }
                        break;
                    default:
                        if (rollScores[currentRoll] < 10)
                        {
                            currentRoll++;
                            rollScores[currentRoll] = Bowl();
                            while (rollScores[currentRoll] + rollScores[currentRoll - 1] > 10)
                            { 
                                Console.WriteLine("Invaild input: Too many pins for this frame!!!");
                                Console.WriteLine("Please enter a value between " + 0 + " and " + (10 - rollScores[currentRoll - 1]));
                                rollScores[currentRoll] = Bowl();
                            }

                            currentRoll++;
                        }
                        else
                        {
                            currentRoll += 2;
                        }
                        break;
                }
            }
            for (int i = 0; i < rollScores.Length; i++)
            {
                Console.Write(rollScores[i] + " ");
            }
            //time to score the game
            for (int i = 0; i < rollScores.Length - 1; i += 2)
            {
                if (rollScores[i] == 10)
                {
                    if (i < rollScores.Length - 3)
                    {
                        if (rollScores[i + 2] == 10)
                        {
                            if (rollScores[i + 4] == 10)
                            {
                                totalScore += rollScores[i] + rollScores[i + 2] + rollScores[i + 4];
                            }
                            else
                            {
                                totalScore += rollScores[i] + rollScores[i + 2] + rollScores[i + 3];
                            }
                        }
                        else
                        {
                            totalScore += rollScores[i] + rollScores[i + 2] + rollScores[i + 3];
                        }
                    }
                    else
                    {
                        totalScore += rollScores[i] + rollScores[i + 1] + rollScores[i + 2];
                    }
                }
                else if (rollScores[i] + rollScores[i + 1] == 10)
                {
                    totalScore += rollScores[i] + rollScores[i + 1] + rollScores[i + 2];
                }
                else
                {
                    totalScore += rollScores[i] + rollScores[i + 1];
                }
            }
            Console.WriteLine("Your total score was: " + totalScore);
            Console.ReadLine();
            
            
            int Bowl()
            {
                    
                    Console.Write("Please Enter the Number of Pins knocked down: ");
                    rollScoreString = Console.ReadLine().Trim();
                    if (!int.TryParse(rollScoreString, out rollScoreInt))
                    {
                        while(int.TryParse(rollScoreString, out rollScoreInt) == false)
                    {
                        Console.WriteLine("Invalid Input!!!");
                        rollScoreString = Console.ReadLine().Trim();
                    }
                }
                return rollScoreInt;
            }
        }
    }
}
