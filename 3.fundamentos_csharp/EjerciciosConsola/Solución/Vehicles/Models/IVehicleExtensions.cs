namespace Vehicles.Models
{
    public static class IVehicleExtensions
    {
        public static string GetSpeedWithUnits(this IVehicle vehicle)
        {
            return $"{vehicle.GetSpeed()} km / h";
        }
    }
}
