namespace _04.PizzaCalories
{
    using System;
    using System.Collections.Generic;

    public class Pizza
    {
        private const int MAX_LENGTH = 15;
        private const int MAX_TOPPING_COUNT = 10;

        private string name;
        private Dough dough;
        private List<Topping> toppings;
        public Pizza(string name)
        {
            this.Name = name;
            this.toppings = new List<Topping>();
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (value.Length > MAX_LENGTH || string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }
        public double TotalCalories()
        {
            return GetDoughCalories() + GetToppingCalories();
        }
        public int numberOfToppings()
        {
            return this.toppings.Count;
        }

        internal void AddDough(Dough dough)
        {
            this.dough = dough;
        }
        internal void AddTopping(Topping topping)
        {
            if (this.toppings.Count == MAX_TOPPING_COUNT)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            this.toppings.Add(topping);
        }
       
        private double GetToppingCalories()
        {
            double toppingCal = 0;
            foreach (var topping in this.toppings)
            {
                toppingCal += topping.GetToppingCalories();
            }
            return toppingCal * 2;
        }
        private double GetDoughCalories()
        {
            return this.dough.GetDoughCalories();
        }
    }
}
