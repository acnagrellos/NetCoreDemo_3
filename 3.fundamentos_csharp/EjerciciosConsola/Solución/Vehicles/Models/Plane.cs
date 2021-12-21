﻿namespace Vehicles.Models
{
    public class Plane : IVehicle
    {
        public int Speed { get; set; }

        public Plane(int speed)
        {
            Speed = speed;
        }

        public void SpeedUp()
        {
            Speed += 100;
        }

        public void Brake()
        {
            var speedTotal = Speed - 20;
            if (speedTotal >= 0)
            {
                Speed = speedTotal;
            }
            else
            {
                throw new Exception("No se puede frenar");
            }
        }

        public int GetSpeed()
        {
            return Speed;
        }
    }
}
