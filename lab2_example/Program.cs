using System;
namespace MyEquations
{
    public interface iTwoNumbers
    {
        sbyte N1 { get; set; }
        sbyte N2 { get; set; }
        void Solve(); void WriteAnswer(string ToWrite);
    }
    public abstract class TTwoNumbers : iTwoNumbers
    {
        sbyte n1; public sbyte N1 { get { return n1; } set { n1 = value; } }
        sbyte n2; public sbyte N2 { get { return n2; } set { n2 = value; } }
        public TTwoNumbers() { N1 = 0; N2 = 0; }
        public TTwoNumbers(sbyte N1, sbyte N2) { this.N1 = N1; this.N2 = N2; }
        public abstract void Solve();
        public void WriteAnswer(string result) { Console.WriteLine(result); }
    }
    class TEquation : TTwoNumbers
    {
        sbyte a { get { return N1; } set { N1 = value; } }
        sbyte b { get { return N2; } set { N2 = value; } }
        public TEquation(sbyte P1, sbyte P2) : base(P1, P2) { }
        public override void Solve()
        {
            Console.WriteLine(": Linear Equation: ({0})x+({1})=0", a, b);
            if (a != 0)
            {
                double x = (double)(b) / a;
                WriteAnswer("Result: x=" + x.ToString("F3"));
            }
            else WriteAnswer("No Answer!");
        }
    }
    class TSquareEquation : TEquation
    {
        sbyte a { get; set; }
        sbyte b { get { return N1; } set { N1 = value; } }
        sbyte c { get { return N2; } set { N2 = value; } }
        public TSquareEquation(sbyte P1, sbyte P2, sbyte P3) : base(P2, P3) { a = P1; }
        public override void Solve()
        {
            Console.WriteLine(": Square Equation: ({0}x*x)+({1})x+({2})=0", a, b, c);
            short D = (short)(b * b - 4 * a * c);
            if (D >= 0)
            {
                double x1 = (-b + Math.Sqrt(D)) / (2 * a);
                double x2 = (-b - Math.Sqrt(D)) / (2 * a);
                WriteAnswer("Result: x1=" + x1.ToString("F3") + ", x2=" + x2.ToString("F3"));
            }
            else WriteAnswer("No Answer! D=" + D.ToString());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            byte CollectionSize = 6; byte i;
            Random random = new Random(); sbyte p1, p2, p3;
            TEquation[] Collection = new TEquation[CollectionSize];
            for (i = 0; i < CollectionSize; i++)
            {
                p1 = (sbyte)random.Next(-10, 10);
                p2 = (sbyte)random.Next(-10, 10);
                p3 = (sbyte)random.Next(-10, 10);
                Console.WriteLine("{0}: Numbers={1},{2},{3}", i + 1, p1, p2, p3);
                Collection[i] = (i < CollectionSize / 2
                ? new TEquation(p1, p2)
                : new TSquareEquation(p1, p2, p3));
            }
            Console.WriteLine(); i = 0;
            foreach (TEquation Equation in Collection)
            { Console.Write(++i); Equation.Solve(); }
            Console.ReadLine();
        }
    }
}