using System;

namespace InheritanceDemo
{
    public class Square
    {
        public double SideLength { get; set; }
        public string Color { get; set; }

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
        public double Perimeter => 2 * (SideLength + Width);

        public new void ShowProperties()
        {
            Console.WriteLine($"Rectangle: Side Length = {SideLength}, Width = {Width}, Area = {Area}, Perimeter = {Perimeter}, Aspect Ratio = {AspectRatio}, Color = {Color}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square { SideLength = 5, Color = "Red" };
            Rectangle rectangle = new Rectangle { SideLength = 5, Width = 10, Color = "Blue" };

            square.ShowProperties();
            rectangle.ShowProperties();
        }
    }
}