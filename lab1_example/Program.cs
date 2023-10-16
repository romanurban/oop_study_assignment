using System;
namespace MyAirline
{
    public class Airplane
    {
        public readonly int MaxPassengers;
        private int passengers;
        private double speed;
        private double altitude;
        private static int airplaneNumber = 0;

        public Airplane(int MaxPassengers)
        {
            this.MaxPassengers = MaxPassengers;
            passengers = 0;
            speed = 0;
            altitude = 0;
            airplaneNumber++;
        }

        public bool IsFull()
        {
            return (passengers == MaxPassengers);
        }

        public int Passengers { get { return passengers; } }
        public double Speed { get { return speed; } }
        public double Altitude { get { return altitude; } }
        public static int AirplanesCount { get { return airplaneNumber; } }

        public void IncSpeed(double delta)
        {
            speed += delta;
        }

        public void IncAltitude(double delta)
        {
            altitude += delta;
        }

        public bool GetAPassenger()
        {
            if (IsFull()) return false;
            else
            {
                passengers++;
                return true;
            }
        }

        public void MakeALanding()
        {
            passengers = 0;
            altitude = 0;
            speed = 0;
        }
    }

    public class AirplaneDemo
    {
        public static void Main()
        {
            Airplane a1 = new Airplane(25);
            Airplane a2 = new Airplane(10);

            while (a1.GetAPassenger()) { }

            for (int i = 0; i < 5 && !a2.IsFull(); i++) { a2.GetAPassenger(); }

            a1.IncSpeed(700); a1.IncAltitude(3000);
            a2.IncSpeed(500); a2.IncAltitude(1000);

            Console.WriteLine("#1:Alt={0},Speed={1},Pass={2}", a1.Altitude, a1.Speed, a1.Passengers);
            Console.WriteLine("#2:Alt={0},Speed={1},Pass={2}", a2.Altitude, a2.Speed, a2.Passengers);

            a1.MakeALanding();
            a2.MakeALanding();

            Console.WriteLine("Total airplanes:{0}", Airplane.AirplanesCount);
            Console.WriteLine("Press Enter...");
            Console.ReadLine();
        }
    }
}