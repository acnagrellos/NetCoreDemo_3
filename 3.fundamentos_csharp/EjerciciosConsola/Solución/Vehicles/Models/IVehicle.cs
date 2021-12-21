namespace Vehicles.Models
{
    public interface IVehicle
    {
        void SpeedUp();
        void Brake();
        int GetSpeed();
    }
}
