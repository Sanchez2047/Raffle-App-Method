using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleUI
{
    class Program
    {

        private static Dictionary<int, string> guests = new Dictionary<int, string>();
        private static int min = 1000;
        private static int max = 9999;
        private static int raffleNumber;
        private static Random rdm = new Random(); 
        private static string GetUserInput(string input)
        {
            Console.WriteLine(input);
            string name = Console.ReadLine();
            return name;
        }
        private static int GenerateRandomNumber(int min, int max)
        {
            return rdm.Next(min, max);
        }
        private static void AddGuestsInRaffle(int raffleNumber, string name)
        {
            guests.Add(raffleNumber,name);
        }
        private static void GetUserInfo()
        {
            string otherGuest;
            do
            {
                string name = GetUserInput("Please Enter Your Name: ");
                while (name == "")
                {
                    name = GetUserInput("Please Enter Your Name: ");
                }
                raffleNumber = GenerateRandomNumber(min, max);
                while (guests.ContainsKey(raffleNumber))
                {
                    raffleNumber = GenerateRandomNumber(min, max);
                }
                AddGuestsInRaffle(raffleNumber, name);
                otherGuest = GetUserInput("Do you want to add another?").ToLower();
            } 
            while(otherGuest == "yes");
        }
        private static void PrintGuestsName()
        {
            foreach(KeyValuePair<int,string> guest in guests)
            {
                Console.WriteLine($"{guest.Value}: {guest.Key}");
            }
        }
        private static int GetRaffleNumber(Dictionary<int, string> people)
        {
            raffleNumber = GenerateRandomNumber(min, max);
            while (!people.ContainsKey(raffleNumber))
            {
                raffleNumber = GenerateRandomNumber(min, max);
            }
            return raffleNumber;
        }
        private static void PrintWinner()
        {
            int winnerNumber = GetRaffleNumber(guests);
            string winnerName = guests[winnerNumber];
            Console.WriteLine($"The Winner is: {winnerName} with the #{winnerNumber}!");
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Party!!");
            GetUserInfo();
            PrintGuestsName();
            GetRaffleNumber(guests);
            PrintWinner();
            Console.ReadLine();

        }

        //Start writing your code here






        static void MultiLineAnimation() // Credit: https://www.michalbialecki.com/2018/05/25/how-to-make-you-console-app-look-cool/
        {
            var counter = 0;
            for (int i = 0; i < 30; i++)
            {
                Console.Clear();

                switch (counter % 4)
                {
                    case 0:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    │││ \\   ║");
                            Console.WriteLine("         ║    │││  O  ║");
                            Console.WriteLine("         ║    OOO     ║");
                            break;
                        };
                    case 1:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                    case 2:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║   / │││    ║");
                            Console.WriteLine("         ║  O  │││    ║");
                            Console.WriteLine("         ║     OOO    ║");
                            break;
                        };
                    case 3:
                        {
                            Console.WriteLine("         ╔════╤╤╤╤════╗");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    ││││    ║");
                            Console.WriteLine("         ║    OOOO    ║");
                            break;
                        };
                }

                counter++;
                Thread.Sleep(200);
            }
        }
    }
}
