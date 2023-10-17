using System;
using System.Collections.Generic;

namespace GeometricalShapes
{
    // Interface
    public interface IShape
    {
        double Area();
        void ShowDetails();
    }

    // Abstract class
    public abstract class Shape : IShape
    {
        public abstract double Area();
        public virtual void ShowDetails()
        {
            Console.WriteLine("This is a shape");
        }
    }

    // Square class
    public class Square : Shape
    {
        public double SideLength { get; set; }

        public Square(double sideLength)
        {
            SideLength = sideLength;
        }

        public override double Area()
        {
            return SideLength * SideLength;
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Square with side length: {SideLength}, area: {Area()}");
        }
    }

    // Rectangle class
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double Area()
        {
            return Width * Height;
        }

        public override void ShowDetails()
        {
            Console.WriteLine($"Rectangle with width: {Width}, height: {Height}, area: {Area()}");
        }
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
                shape.ShowDetails();
            }
        }
    }
}