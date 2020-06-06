namespace P01.ClassBoxData
{
    using System;

    public class Box
    {
        private double length;
        private double width;
        private double height;
        private const string ERROR_MASSAGE = "cannot be zero or negative.";

        public Box(double lenght, double width, double height)
        {
            this.Length = lenght;
            this.Width = width;
            this.Height = height;
        }

        public double Length
        {
            get
            {
                return this.length;
            }
            private set
            {
                this.ValidateSide(value, nameof(this.Length));
                this.length = value;
            }
        }
        public double Width
        {
            get
            {
                return this.width;
            }
            private set
            {
                this.ValidateSide(value, nameof(this.Width));
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            private set
            {
                this.ValidateSide(value, nameof(this.Height));
                this.height = value;
            }
        }

        public double GetSurfaceArea()
        {
            return (this.Length * this.Width) * 2 + GetLateralSurfaceArea();
        }

        public double GetLateralSurfaceArea()
        {
            return (this.Length * this.Height) * 2 +
                   (this.Width * this.Height) * 2;
        }
        public double GetVolume()
        {
            return this.Length * this.Width * this.Height;
        }
        private void ValidateSide(double value, string side)
        {
            if (value <= 0)
            {
                throw new ArgumentException($"{side} {ERROR_MASSAGE}");
            }
        }
    }
}
