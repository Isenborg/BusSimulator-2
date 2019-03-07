using System;
using System.Collections.Generic;
using System.Text;

namespace BusSimulator
{
    class Games
    {
        public void TotalAgeGame()
        {
            Console.Clear();
            List<Passengers> passengers = new List<Passengers>();
            Random r = new Random();
            var bussen = new Buss();
            int TotalAge = 0;
            int choice;
            int NumberGoal = r.Next(75, 750);
            Console.WriteLine("This is a game where you want to reach a certain Total age of the passangers by adding and removing them." +
                "\nPress any button to begin! Good luck...");
            Console.ReadKey();
            Console.Clear();
            bool EndGame = false;
            var StartTime = DateTime.Now;
            do
            {
                Console.WriteLine("The Total Age you want to reach is " + NumberGoal + "| The Current Total Age is " + TotalAge);
                bussen.ShowPassengers(true);
                bussen.GameMenu();
                choice = bussen.StringToNum();
                switch(choice)
                {
                    case 1:
                        bussen.add_passenger();
                        break;
                    case 2:
                        bussen.RemovePassengerAtIndex();
                        break;
                    case 3:
                        EndGame = true;
                        break;
                }
                TotalAge = bussen.calc_total_age();
                Console.Clear();
            } while (!(TotalAge == NumberGoal) && !EndGame);
            var EndTime = DateTime.Now;
            var TotalTime = (EndTime - StartTime).TotalSeconds;
            Console.WriteLine("you won, and it took " + TotalTime + " Seconds");
            Console.ReadKey();
        }
    }
}
