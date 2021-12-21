namespace Vehicles.Models
{
    public class Car : IVehicle
    {
        public int Speed { get; set; }

        public Car(int speed)
        {
            Speed = speed;
        }

        public void SpeedUp()
        {
            Speed += 20;
        }

        public void Brake()
        {
            var speedTotal = Speed - 5;
            if (speedTotal >= 0)
            {
                Speed = speedTotal;
            }
            else
            {
                throw new Exception("The speed is 0, so it can't brake.");
            }
        }

        public int GetSpeed()
        {
            return Speed;
        }
    }
}
