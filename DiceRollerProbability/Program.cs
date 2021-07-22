using System;

namespace DiceRollerProbability
{
    class Program
    {
        static void Main(string[] args)
        {

            Random nextDice = new Random();
            int[] rolling = new int[36000];
            const int MAX_DICE_VALUE = 7;
            const int MIN_DICE_VALUE = 1;

            int sum = 0, count = 0, userChoice = 0;

            for (int i = 0; i < rolling.Length; i++)
            {
                int firstDice = nextDice.Next(MIN_DICE_VALUE, MAX_DICE_VALUE);
                int secondDice = nextDice.Next(MIN_DICE_VALUE, MAX_DICE_VALUE);
                sum = firstDice + secondDice;
                rolling[i] = sum;
            }
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");
            Console.WriteLine("Two Dice has finished rolling and gethered sum of each roll ");
            Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++");

            while (userChoice != 2)
            {
                label:
                
                Console.Write("\nEnter the sum (2-12) to see how many times it occured => ");
                int checkSum = Convert.ToInt32(Console.ReadLine());

                if ( checkSum > 12 || checkSum < 2)
                {
                    Console.WriteLine("--------------------------------------------");
                    Console.WriteLine("\tLogically incorrect input");
                    Console.WriteLine("--------------------------------------------");
                    goto toContinue;                                                    // jump if user enters invalid value and then ask user if they want to continue or not !
                }

                for (int i = 0; i < rolling.Length; i++)
                {
                    if (checkSum == rolling[i])                                         // if user value exists inside the rolling data
                    {
                        count++;                                                        // increment that value's count by 1
                    }
                }
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("\nSum -> {0}  \nOccured -> {1}  times.", checkSum, count);           // output statement
                Console.WriteLine("-----------------------------------------------------------");

                toContinue:  // if user entered invalid value, they are redirected here

                Console.WriteLine("\nDo you want to try again ? ");
                
                Console.WriteLine("\nPress 1 to continue");
                Console.WriteLine("Press 2 to exit");

                Console.Write("\nSelect an above option => ");
                userChoice = Convert.ToInt32(Console.ReadLine());
                
                if ( userChoice == 1)
                {
                    goto label;
                }
                else if ( userChoice == 2)
                {
                    Console.WriteLine("\nExiting...");
                    break;
                }
            }
            Console.WriteLine("\nEnter any key to exit");
        }
    }
}
