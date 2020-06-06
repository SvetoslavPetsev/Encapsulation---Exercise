namespace _04.PizzaCalories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Dough
    {
        private const int MIN_WEIGHT = 1;
        private const int MAX_WEIGHT = 200;
        private const string EXCEPTION_MESSAGE = "Invalid type of dough.";

        private const double White = 1.5;
        private const double Wholegrain = 1.0;
        private const double Crispy = 0.9;
        private const double Chewy = 1.1;
        private const double Homemade = 1.0;


        private double weight;
        private string doughName;
        private string bakeType;

        public Dough(string doughName, string bakeType, double weight)
        {

            this.DoughName = doughName;
            this.BakeType = bakeType;
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
                if (value < MIN_WEIGHT || value > MAX_WEIGHT)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }
        public string DoughName
        {
            get
            {
                return this.doughName;
            }
            private set
            {

                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException(EXCEPTION_MESSAGE);
                }

                this.doughName = value;
            }
        }
        public string BakeType
        {
            get
            {
                return this.bakeType;
            }
            private set
            {

                if (value.ToLower() != "crispy"
                 && value.ToLower() != "chewy"
                 && value.ToLower() != "homemade")
                {
                    throw new ArgumentException(EXCEPTION_MESSAGE);
                }

                this.bakeType = value;
            }
        }
        public double GetDoughCalories()
        {
            List<string> bakeTechnology = new List<string> { this.doughName, this.bakeType };
            
            double cal = 1;
            foreach (var dough in bakeTechnology.Select(x => x.ToLower()))
            {
                if (dough == "white")
                {
                    cal *= White;
                }
                else if (dough == "wholegrain")
                {
                    cal *= Wholegrain;
                }
                else if (dough == "crispy")
                {
                    cal *= Crispy;
                }
                else if (dough == "chewy")
                {
                    cal *= Chewy;
                }
                else if (dough == "homemade")
                {
                    cal *= Homemade;
                }
            }
            return cal * this.Weight * 2;
        }
    }
}
