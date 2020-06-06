namespace P03.ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Engine
    {
        private List<Person> persons;
        private List<Product> products;
        public Engine()
        {
            this.persons = new List<Person>();
            this.products = new List<Product>();
        }

        public void Run()
        {

            try
            {
                string[] inputPeople = ReadFromConsole();
                foreach (var personInfo in inputPeople.Where(x => x != null))
                {
                    string[] info = personInfo.Split("=");
                    string name = info[0];
                    decimal money = decimal.Parse(info[1]);
                    Person person = new Person(name, money);
                    this.persons.Add(person);
                }

                string[] inputProducts = ReadFromConsole();
                foreach (var productInfo in inputProducts)
                {
                    string[] info = productInfo.Split("=");
                    string name = info[0];
                    decimal cost = decimal.Parse(info[1]);
                    Product someProduct = new Product(name, cost);
                    this.products.Add(someProduct);

                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string cmd;
            while ((cmd = Console.ReadLine()) != "END")
            {
                string[] info = cmd.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string personName = info[0];
                string productName = info[1];

                var person = this.persons.FirstOrDefault(x => x.Name == personName);
                var product = this.products.FirstOrDefault(x => x.Name == productName);
                if (person.Money >= product.Cost)
                {
                    person.Money -= product.Cost;
                    person.Bag.Add(product);
                    Console.WriteLine($"{person.Name} bought {product.Name}");
                }
                else
                {
                    Console.WriteLine($"{person.Name} can't afford {product.Name}");
                }
            }
            this.Print();
        }

        private void Print()
        {
            foreach (var person in this.persons)
            {
                if (!person.Bag.Any())
                {
                    Console.WriteLine($"{person.Name} - Nothing bought ");
                    continue;
                }

                foreach (var item in person.Bag)
                {

                }
                Console.WriteLine($"{person.Name} - {string.Join(", ", person.Bag)}");
            }
        }

        private string[] ReadFromConsole()
        {
            return Console.ReadLine().Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
