using System;
using System.Collections.Generic;
using System.Linq;
//Nedan är namnet på "namespace" - alltså projektet. 
//SKapa ett nytt konsollprojekt med namnet "Bussen" så kan ni kopiera över all koden rakt av från denna fil
namespace BusSimulator
{
	class Buss
	{
		
		public void Run()
		{
            List<Passengers> passengers = new List<Passengers>();
            bool ShowPassenger = false;
            int choice;
            Random r = new Random();
            var Handler = new PassengerHandler();
            var person = new Passengers();
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
                }
                Console.WriteLine("[1]: Help\n[2]: Add Passenger\n[3]: Remove Passenger\n[4]: Show Passengers\n[5]: Sort Passengers");
                while (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.Write("Enter a valid input: ");
                }
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Help");
                        break;
                    case 2:
                        person = Handler.GetPassenger();
                        passengers.Add(Handler.GetPassenger());
                        break;

                    case 3:
                        Console.WriteLine("[1]: Random Passenger\n[2]: Passenger By Index");
                        while (!int.TryParse(Console.ReadLine(), out choice))
                        {
                            Console.Write("Enter a valid input: ");
                        }
                        switch(choice)
                        {
                            case 1:
                                if (passengers.Count > 0) passengers.RemoveAt(r.Next(0, passengers.Count - 1));
                                else
                                {
                                    Console.WriteLine("No passengers to be removed.");
                                    Console.ReadKey();
                                }
                                break;
                            case 2:
                                int index;
                                while (!int.TryParse(Console.ReadLine(), out index))
                                {
                                    Console.Write("Enter a valid input: ");
                                }
                                if (passengers.Count > 0) passengers.RemoveAt(index+1);
                                else
                                {
                                    Console.WriteLine("No passengers to be removed.");
                                    Console.ReadKey();
                                }
                                break;
                        }
                        break;
                    case 4:
                        if (ShowPassenger == false) ShowPassenger = true;
                        else ShowPassenger = false;
                        break;

                    case 5:
                        Console.WriteLine("[1]: Sort By Age (Lowest First)\n[2]: Sort By Age (Highest First)\n[3]: Sort By Income (Lowest First)\n[4]: Sort By Income (Highest First)");
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
                        }
                        break;
                } 
				Console.Clear();   
            } while (true);
        }

		//Metoder för betyget E
		
		public void add_passenger()
		{
			//Lägg till passagerare. Här skriver man då in ålder men eventuell annan information.
			//Om bussen är full kan inte någon passagerare stiga på

		}
		
		public void print_buss()
		{
			//Skriv ut alla värden ur vektorn. Alltså - skriv ut alla passagerare
		}
		
		public int calc_total_age()
		{
			//Beräkna den totala åldern. 
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
            return 0;
    	}
		
		//Metoder för betyget C
		
		public int calc_average_age()
		{
			//Betyg C
			//Beräkna den genomsnittliga åldern. Kanske kan man tänka sig att denna metod ska returnera något annat värde än heltal?
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
            return 0;
        }
		
		public int max_age()
		{
			//Betyg C
			//ta fram den passagerare med högst ålder. Detta ska ske med egen kod och är rätt klurigt.
			//För att koden ska fungera att köra så måste denna metod justeras, alternativt att man temporärt sätter metoden med void
            return 0;
        }
		
		public void find_age()
		{
			//Visa alla positioner med passagerare med en viss ålder
			//Man kan också söka efter åldersgränser - exempelvis 55 till 67
			//Betyg C
			//Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 149)

		}
		
		public void sort_buss()
		{
			//Sortera bussen efter ålder. Tänk på att du inte kan ha tomma positioner "mitt i" vektorn.
			//Beskrivs i läroboken på sidan 147 och framåt (kodexempel på sidan 159)
			//Man ska kunna sortera vektorn med bubble sort
		}
		
		//Metoder för betyget A
		
		
		public void print_sex()
		{
			//Betyg A
			//Denna metod är nödvändigtvis inte svårare än andra metoder men kräver att man skapar en klass för passagerare.
			//Skriv ut vilka positioner som har manliga respektive kvinnliga passagerare.
		}	
		public void poke()
		{
			//Betyg A
			//Vilken passagerare ska vi peta på?
			//Denna metod är valfri om man vill skoja till det lite, men är också bra ur lärosynpunkt.
			//Denna metod ska anropa en passagerares metod för hur de reagerar om man petar på dom (eng: poke)
			//Som ni kan läsa i projektbeskrivningen så får detta beteende baseras på ålder och kön.
		}	
		
		public void getting_off()
		{
			//Betyg A
			//En passagerare kan stiga av
			//Detta gör det svårare vid inmatning av nya passagerare (som sätter sig på första lediga plats)
			//Sortering blir också klurigare
			//Den mest lämpliga lösningen (men kanske inte mest realistisk) är att passagerare bakom den plats..
			//.. som tillhörde den som lämnade bussen, får flytta fram en plats.
			//Då finns aldrig någon tom plats mellan passagerare.
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