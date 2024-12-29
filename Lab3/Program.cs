using System;
using System.Text.Json;

namespace Lab3
{
    public class Person
    {
        public int id { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string email { get; set; }
        public int balance { get; set; }
    }
    internal class Program
    {
        
        static void Main(string[] args)
        {
            string json = File.ReadAllText("D:\\Labs\\PromProg\\Lab3\\lab3.json");
            List<Person> peoples = JsonSerializer.Deserialize<List<Person>>(json);
            foreach(Person person in peoples)
            {
                if (person.balance < 0)
                {
                    Console.WriteLine(person.first_name + " " + person.last_name);
                }
            }
            
        }
    }
}
