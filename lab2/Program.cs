using System;
using System.Collections.Generic;

namespace GeometricalShapes
{
    // Interface
    public interface IShape
    {
        double Area();
        double Perimeter();
        string? Color { get; set; }
        void ShowProperties();
    }

    // Abstract class
    public abstract class Shape : IShape
    {
        public abstract double Area();
        public abstract double Perimeter();
        public string? Color { get; set; }
        public virtual void ShowProperties()
        {
            Console.WriteLine("This is a shape");
        }
    }

    public class Square : Shape
	{
		private double _sideLength;
		public double SideLength
		{
			get { return _sideLength; }
			set
			{
				if (value <= 0)
				{
					throw new ArgumentException("Side length must be greater than zero.");
				}
				_sideLength = value;
			}
		}

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

		public override double Area()
        {
            return SideLength * SideLength;
        }

        public override double Perimeter()
        {
            return 4 * SideLength;
        }

        public override void ShowProperties()
        {
            Console.WriteLine($"Square: Side Length = {SideLength}, Area = {Area()}, Perimeter = {Perimeter()}, Color = {Color}");
        }
	}

    public class Rectangle : Square
    {
        public double Width { get; set; }

        // call the base class constructor and pass sideLength to it
        public Rectangle(double sideLength, double width) : base(sideLength)
        {
            this.Width = width;
        }

        public override double Area()
        {
            return SideLength * Width;
        }

        public override double Perimeter()
        {
            return 2 * (SideLength + Width);
        }

        public override void ShowProperties()
        {
            Console.WriteLine($"Rectangle: Side Length = {SideLength}, Width = {Width}, Area = {this.Area()}, Perimeter = {this.Perimeter()}, Aspect Ratio = {Math.Round(AspectRatio, 2)}, Color = {Color}");
        }

        public double AspectRatio => Width / SideLength;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> shapes = new List<Shape>();
            Random rand = new Random();

            // Adding random squares
            for (int i = 0; i < 5; i++)
            {
                double sideLength = rand.Next(1, 101); // Random length between 1 and 100
                shapes.Add(new Square(sideLength));
            }

            // Adding random rectangles
            for (int i = 0; i < 5; i++)
            {
                double width = rand.Next(1, 101); // Random width between 1 and 100
                double height = rand.Next(1, 101); // Random height between 1 and 100
                shapes.Add(new Rectangle(width, height));
            }

            // Display details
            foreach (Shape shape in shapes)
            {
                shape.ShowProperties();
            }
        }
    }
}