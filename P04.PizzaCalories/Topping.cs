namespace _04.PizzaCalories
{
    using System;

    public class Topping
    {
        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 50;

        private const double Meat = 1.2;
        private const double Veggies = 0.8;
        private const double Cheese = 1.1;
        private const double Sauce = 0.9;
        
        private double weight;
        private string type;

        public Topping(double weight, string type)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public double Weight
        {
            get
            {
                return this.weight;
            }
            private set
            {
                if (value < MIN_WEIGHT || value > MAX_WEIGHT )
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }
        public string Type
        {
            get
            {
                return this.type;
            }
            private set
            {
                if (value.ToLower() != "meat"
                      && value.ToLower() != "veggies"
                      && value.ToLower() != "cheese"
                      && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }
        public double GetToppingCalories()
        {
            double toppingTypeCal = 0;

            if (this.Type.ToLower() == "meat")
            {
                toppingTypeCal = Meat;
            }
            else if (this.Type.ToLower() == "veggies")
            {
                toppingTypeCal = Veggies;
            }
            else if (this.Type.ToLower() == "cheese")
            {
                toppingTypeCal = Cheese;
            }
            else if (this.Type.ToLower() == "sauce")
            {
                toppingTypeCal = Sauce;
            }
            return toppingTypeCal * this.weight;
        }
    }
}
