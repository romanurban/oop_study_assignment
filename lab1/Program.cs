using System;

namespace InheritanceDemo
{
    public class Square
    {
        // encapsulated property
        private double sideLength;
        // public getter/setter
        public double SideLength
        {
            get { return sideLength; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Side length must be greater than zero.");
                }
                sideLength = value;
            }
        }

        public string? Color { get; set; }

        public double Area => SideLength * SideLength;
        public double Perimeter => 4 * SideLength;

        public void ShowProperties()
        {
            Console.WriteLine($"Square: Side Length = {SideLength}, Area = {Area}, Perimeter = {Perimeter}, Color = {Color}");
        }
    }

    public class Rectangle : Square
    {
        public double Width { get; set; }

        public new double Area => SideLength * Width;
        public double AspectRatio => Width / SideLength;
        public new double Perimeter => 2 * (SideLength + Width);

        public new void ShowProperties()
        {
            Console.WriteLine($"Rectangle: Side Length = {SideLength}, Width = {Width}, Area = {Area}, Perimeter = {Perimeter}, Aspect Ratio = {AspectRatio}, Color = {Color}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Square square1 = new Square { SideLength = 5, Color = "Red" };
                // rectangle that inherits square
                Rectangle rectangle = new Rectangle { SideLength = 5, Width = 10, Color = "Blue" };

                square1.ShowProperties();
                rectangle.ShowProperties();

                // Square with a negative side length to trigger an ArgumentException
                Square square2 = new Square { SideLength = -5, Color = "Green" };
                square2.ShowProperties();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"An error occurred: {e.Message}");
            }
        }
    }
}
