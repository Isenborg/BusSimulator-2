using System;
using System.Collections.Generic;
using System.IO;
//Nedan är namnet på "namespace" - alltså projektet. 
//SKapa ett nytt konsollprojekt med namnet "Bussen" så kan ni kopiera över all koden rakt av från denna fil
namespace BusSimulator
{
	class Buss
	{
        public List<Passengers> passengers = new List<Passengers>();
        public Random r = new Random();

        public void Run()
		{
            ScrapeAll();
            bool ShowPassenger = false;
            int choice;
            
            
            Console.WriteLine("Welcome to the awesome Buss-simulator! \nPress any button to continue . . .");
            Console.ReadKey();
            Console.Clear();
            do
            {
                if (ShowPassenger == true)
                {
                    int i = 1;
                    foreach (var onscreen in passengers)
                    {
                        Console.WriteLine($"[{i}]Name: {onscreen.Name} | Age: {onscreen.Age} | Gender: {onscreen.Gender} | Job: {onscreen.Job} | Income: {onscreen.Income}");
                        i++;
                    }
                    Console.WriteLine();
                    Console.WriteLine($"[]: Add Passenger" +
                    "\n[2]: Remove Passenger" +
                    "\n[3]: Show Passengers (ON)" +
                    "\n[4]: Sort Passengers" +
                    "\n[5]: Poke Passenger" +
                    "\n[6]: Statistics");
                }
                else
                {
                    Console.WriteLine("[1]: Add Passenger" +
                    "\n[2]: Remove Passenger" +
                    "\n[3]: Show Passengers (OFF)" +
                    "\n[4]: Sort Passengers" +
                    "\n[5]: Poke Passenger" +
                    "\n[6]: Statistics"); 
                }

                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Enter a valid input: ");
                }
                switch (choice)
                {
                    case 1:
                        add_passenger();
                        break;

                    case 2:
                        Console.WriteLine("[1]: Random Passenger" +
                            "\n[2]: Passenger By Index" +
                            "\n[3]: All Passengers");
                        while (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.Write("Enter a valid input: ");
                        }
                        switch(choice)
                        {
                            case 1:
                                RemoveRandomPassenger();
                                break;
                            case 2:
                                RemovePassengerAtIndex();
                                break;
                            case 3:
                                RemoveAllPassengers();
                                break;
                        }
                        break;
                    case 3:
                        if (ShowPassenger == false) ShowPassenger = true;
                        else ShowPassenger = false;
                        break;

                    case 4:
                        Console.WriteLine("[1]: Sort By Age (Lowest First)" +
                            "\n[2]: Sort By Age (Highest First)" +
                            "\n[3]: Sort By Income (Lowest First)" +
                            "\n[4]: Sort By Income (Highest First)" +
                            "\n[5]: Sort By Name (Alphabetic)");
                        while (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.Write("Enter a valid input: ");
                        }
                        switch (choice)
                        {
                            case 1:
                                passengers.Sort(delegate (Passengers x, Passengers y)
                                {
                                    return x.Age.CompareTo(y.Age);
                                });
                                break;

                            case 2:
                                passengers.Sort(delegate (Passengers x, Passengers y)
                                {
                                    return y.Age.CompareTo(x.Age);
                                });
                                break;

                            case 3:
                                passengers.Sort(delegate (Passengers x, Passengers y)
                                {
                                    return x.Income.CompareTo(y.Income);
                                });
                                break;

                            case 4:
                                passengers.Sort(delegate (Passengers x, Passengers y)
                                {
                                    return y.Income.CompareTo(x.Income);
                                });
                                break;
                            case 5:
                                passengers.Sort(delegate (Passengers x, Passengers y)
                                {
                                    return x.Name.CompareTo(y.Name);
                                });
                                break;
                        }
                        break;

                    case 5:
                        int index;
                        Console.Write("Enter the index of the person you want to poke: ");
                        while (!int.TryParse(Console.ReadLine(), out index))
                        {
                            Console.Write("Enter a valid input: ");
                        }
                        poke(index);
                        Console.ReadKey();
                        break;

                    case 6:
                        Console.WriteLine("[1]: Total Age" +
                            "\n[2]: Average Age" +
                            "\n[3]: Highest Age");
                        while (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.Write("Enter a valid input: ");
                        }
                        switch (choice)
                        {
                            case 1:
                                calc_total_age();
                                Console.ReadKey();
                                break;

                            case 2:
                                calc_average_age();
                                Console.ReadKey();
                                break;

                            case 3:
                                max_age();
                                Console.ReadKey();
                                break;
                        }
                        break;
                } 
				Console.Clear();   
            } while (true);
        }

		//Metoder för betyget E
		public void ScrapeAll()
        {
            if (!File.Exists("c:scrape/jobs.json"))
            {
                var jobscraper = new JobScraper();
                jobscraper.Start();
            }
            if (!File.Exists("c:scrape/names.json"))
            {
                var namescraper = new NameScraper();
                namescraper.Start();
            }
        }


		public void add_passenger()
		{
            var Handler = new PassengerHandler();
            var person = new Passengers();
            if (passengers.Count >= 15)
            {
                Console.WriteLine("The bus is too full to accept more passengers");
                Console.ReadKey();
            }
            else
            {
                person = Handler.GetPassenger();
                passengers.Add(Handler.GetPassenger());
            }
        }
		
        public void RemoveRandomPassenger()
        {
            if (passengers.Count > 0) passengers.RemoveAt(r.Next(0, passengers.Count - 1));
            else
            {
                Console.WriteLine("No passengers to be removed.");
                Console.ReadKey();
            }
        }

        public void RemovePassengerAtIndex()
        {
            int index;
            Console.Write("Enter who should be removed: ");
            while (!int.TryParse(Console.ReadLine(), out index))
            {
                Console.Write("Enter a valid input: ");
            }
            if (index < 1)
            {
                Console.WriteLine();
            }
            else if (index < passengers.Count)
            {

            }
            else if (passengers.Count > 0) passengers.RemoveAt(index - 1);
            else
            {
                Console.WriteLine("No passengers to be removed.");
                Console.ReadKey();
            }
        }

        public void RemoveAllPassengers()
        {
            if (passengers.Count == 0)
            {
                Console.WriteLine("No passengers to be removed");
                Console.ReadKey();
            }
            passengers.RemoveRange(0, passengers.Count);
        }

		public void calc_total_age()
		{
            int TotalAge = 0;
            foreach(var calc in passengers)
            {
                TotalAge += calc.Age;
            }
            Console.WriteLine("The total age of the passengers in the bus is " + TotalAge);
            Console.ReadKey();
    	}
		
		//Metoder för betyget C
		
		public void calc_average_age()
		{
            int AverageAge = 0;
            foreach(var calc in passengers)
            {
                AverageAge += calc.Age;
            }
            AverageAge = AverageAge / passengers.Count;
            Console.WriteLine("The average age of the passengers in the bus is " + AverageAge);
        }
		
		public void max_age()
		{
            int max_age = 0;
            foreach(var calc in passengers)
            {
                if(calc.Age > max_age)
                {
                    max_age = calc.Age;
                }
            }
            Console.WriteLine("The highest age of any passenger in the bus is " + max_age);
        }

		public void poke(int index)
		{
            int i = 1;
            foreach(var poked in passengers)
            {
                if(i == index)
                {
                    Console.WriteLine($"{poked.Name} says: {poked.Message} ");
                }
                i++;
            }
		}	
	}
	
	class Program
	{
		public static void Main(string[] args)
		{
			//Skapar ett objekt av klassen Buss som heter minbuss
			//Denna del av koden kan upplevas väldigt förvirrande. Men i sådana fall är det bara att "skriva av".
			var minbuss = new Buss();
			minbuss.Run();

			Console.ReadKey(true);
		}
	}
}