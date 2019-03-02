using Newtonsoft.Json;
using System.IO;
using System;
using System.Collections.Generic;

namespace BusSimulator
{
    public class Passengers
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string Gender { get; set; }

        public int Age { get; set; }
        public int Income { get; set; }      
    }

    class PassengerHandler
    {
        public Random r = new Random();

        public Passengers GetPassenger()
        {
            Passengers person;
            string gender = GetGender();
            int age = GetAge();
            int income = GetIncome(age);
            string job = GetJob(r.Next(2, 93), age);

            if (gender == "Male")
            {
                if (age <= 18)
                {
                    person = (new Passengers() { Name = GetName(r.Next(101, 201)), Job = job, Age = age, Gender = gender, Income = income });
                }
                else
                {
                    person = (new Passengers() { Name = GetName(r.Next(101, 201)), Job = job, Age = age, Gender = gender, Income = income });
                }
            }
            else
            {
                if (age <= 18)
                {
                    person = (new Passengers() { Name = GetName(r.Next(1, 101)), Job = job, Age = age, Gender = gender, Income = income });
                }
                else
                {
                    person = (new Passengers() { Name = GetName(r.Next(1, 101)), Job = job, Age = age, Gender = gender, Income = income });
                }
            }
            return person;
        }

        public int GetAge()
        {
            int Age = 0;
            if (r.Next(1, 50) > 10) Age = r.Next(12, 60);
            else
            {
                if (r.Next(1, 3) == 1) Age = r.Next(1, 12);
                else Age = r.Next(61, 90);
            }
            return Age;
        }

        public string GetName(int pos)
        {
            string[] json;
            json = File.ReadAllLines("c:Scrape/Names.json");
            Passengers name = JsonConvert.DeserializeObject<Passengers>(json[pos]);
            return name.Name;
        }

        public string GetJob(int pos, int age)
        {
            if (age <= 18) return "unemployed";
            else if (age > 65) return "retired";
            else
            {
                string[] json;
                json = File.ReadAllLines("c:Scrape/Jobs.json");
                Passengers job = JsonConvert.DeserializeObject<Passengers>(json[pos]);
                return job.Job;
            }
        }

        public string GetGender()
        {
            int Num = r.Next(1, 3);
            string gender;
            if (Num == 1) gender = "Male";
            else gender = "Female";
            return gender;
        }

        public int GetIncome(int age)
        {
            double income = 0;
            if (age <= 18) income = 0;
            else if (age > 65) income = 20000;
            else income = Math.Pow(age, 2) * Math.Sqrt(age) + 20000;

            return (int)income;
        }
    }
}