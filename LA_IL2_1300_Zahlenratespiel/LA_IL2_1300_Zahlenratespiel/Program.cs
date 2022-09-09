using System;

namespace LA_IL2_1300_Zahlenratespiel 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variablen Deklaration
            bool exitLoop = true;

            int playerInput;
            Console.WriteLine("Willkommen beim Zahlenratespiel\n------------------------------------------------");
            Console.WriteLine("In diesem Spiel müssen sie Zahlen erraten.\nSie können auch mich Zahlen erraten lassen.\nViel Spass");
            Console.ReadLine();

            do
            {
                Console.WriteLine("Bitte wählen sie einen Gamemode:\nZahlen raten\t[1]\nZahl erfinden\t[2]");
                playerInput = GetInt(true, 1, 2);
                if (playerInput == 1)
                {
                    Console.WriteLine("Bitte wählen sie den Schwierigkeitsgrad:");
                    Console.WriteLine("einfach:\t[1]\nmittel:\t\t[2]\nschwer:\t\t[3]\ncustom:\t\t[4]");
                    playerInput = GetInt(true, 1, 4);
                    switch (playerInput)
                    {
                        case 1:
                            NumberGuessing(1, 10);
                            break;
                        case 2:
                            NumberGuessing(1, 100);
                            break;
                        case 3:
                            NumberGuessing(1, 1000);
                            break;
                        case 4:
                            Console.Clear();
                            int[] minAndMaxNumber = GetRancheInt();
                            NumberGuessing(minAndMaxNumber[0], minAndMaxNumber[1]);
                            break;

                        default:
                            Console.WriteLine("Keine Zahl wurde gewählt!");
                            break;
                    }

                }
                else
                {
                    NumberFinding();
                }

                exitLoop = GetBoolean("Wollen sie weiter spielen?[y/n]");
                Console.Clear();
            } while (exitLoop);
        }

        static void NumberGuessing(int minNumber, int maxNumber)
        {
            Console.Clear();
            bool stillSearchingNumber = true;
            Random rd = new Random();
            int numberToFind = rd.Next(minNumber, maxNumber + 1);

            Console.WriteLine("Die Zahl wurde Generiert.");
            int tries = 0;

            do
            {
                tries++;
                Console.WriteLine($"Die Zahl is zwischen {minNumber} and {maxNumber}.");
                int playerGuess = GetInt(false, 1, 1);
                Console.Clear();

                if (playerGuess < minNumber || playerGuess > maxNumber)
                {
                    Console.WriteLine($"[Genervt]Die Zahl ist zwischen {minNumber} und {maxNumber}");
                    tries += 69;
                }
                else
                {
                    if (playerGuess == numberToFind)
                    {
                        stillSearchingNumber = false;
                        Console.WriteLine($"Glückwunsch sie haben die Zahl gefunden!\nSie haben {tries} Versuche gebraucht.");
                        Console.ReadKey();
                    }
                    else if (playerGuess < numberToFind)
                    {
                        Console.WriteLine("Die Zahl ist zu klein.");
                        minNumber = playerGuess;
                    }
                    else
                    {
                        Console.WriteLine("Die Zahl ist zu gross.");
                        maxNumber = playerGuess;
                    }
                }
            } while (stillSearchingNumber);

            return;
        }

        static void NumberFinding()
        {
            bool done = true;
            int minNum;
            int maxNum;
            int tries = 0;
            int guess;

            Console.Clear();
            Console.WriteLine("Bitte denken sie sich eine Zahl aus.\nNun müssen sie den Bereich auswählen in dem ich raten soll.");
            int[] guessingRange = GetRancheInt();
            minNum = guessingRange[0];
            maxNum = guessingRange[1];

            do
            {
                tries++;
                if (maxNum - minNum <= 1)
                {
                    Random rd = new Random();
                    if (rd.Next(1, 3) == 1)
                    {
                        guess = minNum;
                    }
                    else
                    {
                        guess = maxNum;
                    }
                }
                else
                {
                    guess = (maxNum + minNum) / 2;
                }

                Console.Clear();
                Console.WriteLine($"Ist es die Zahl {guess}\nJa\t\t[1]\nzu klein\t[2]\nzu gross\t[3]");
                switch (GetInt(true, 1, 3))
                {
                    case 1:
                        Console.WriteLine($"Yeah!!Ich habe {tries} Versuche gebraucht.");
                        done = false;
                        break;
                    case 2:
                        minNum = guess;
                        break;
                    case 3:
                        maxNum = guess;
                        break;

                    default:
                        Console.WriteLine("etwas ist schief gelaufen");
                        break;
                }

            } while (done);

            return;
        }

        static int GetInt(bool shouldCheckNumber, int minNumber, int maxNumber)
        {
            int input;

            while (true)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                    if (shouldCheckNumber)
                    {
                        if (input < minNumber || input > maxNumber)
                        {
                            Console.WriteLine("Die Zahl ist zu gross oder zu klein.");
                        }
                        else
                        {
                            return input;
                        }
                    }
                    else
                    {
                        return input;
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Der Input ist Inkorrekt!");
                }
            }
        }

        static int[] GetRancheInt()
        {
            while (true)
            {
                Console.WriteLine("Bitte geben sie die kleinst mögliche Zahl ein:");
                int minNum = GetInt(false, 1, 1);

                Console.WriteLine("Bitte geben sie die grösst mögliche Zahl ein:");
                int maxNum = GetInt(false, 1, 1);
                int[] result = new int[2];

                if (minNum < maxNum)
                {
                    result[0] = minNum;
                    result[1] = maxNum;
                    return result;
                }
                else
                {
                    Console.WriteLine("Die Zahlen sind Falsch");
                }
            }
        }

        static bool GetBoolean(string question)
        {
            string userInput;

            while (true)
            {
                Console.WriteLine(question);
                userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "y":
                        return true;
                    case "n":
                        return false;
                    default:
                        Console.WriteLine("Der Input ist inkorekt");
                        Console.Clear();
                        break;
                }
            }
        }
    }
}