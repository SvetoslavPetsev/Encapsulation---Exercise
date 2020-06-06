namespace _04.PizzaCalories
{
    using System;

    public class Engine
    {
        public void Run()
        {
            try
            {
                string[] pizzaInfo = Console.ReadLine().Split();
                string pizzaName = pizzaInfo[1];
                Pizza pizza = new Pizza(pizzaName);

                string[] doughtsInfo = Console.ReadLine().Split();
                string doughName = doughtsInfo[1];
                string bakeType = doughtsInfo[2];
                double weight = double.Parse(doughtsInfo[3]);
                Dough dough = new Dough(doughName, bakeType, weight);

                pizza.AddDough(dough);

                string toppings;
                while ((toppings = Console.ReadLine()) != "END")
                {
                    string[] toppingInfo = toppings.Split();
                    string name = toppingInfo[1];
                    weight = double.Parse(toppingInfo[2]);
                    var topping = new Topping(weight, name);

                    pizza.AddTopping(topping);
                }
                Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():F2} Calories.");

            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }
    }
}
