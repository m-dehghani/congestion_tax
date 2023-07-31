using Domain.Entities;
using Domain.Entities.Abstract;
using Domain.Entities.Concrete;

namespace Congestion_tax_calculator_UI.Services
{
    public static class VehicleFactory
    {
        static readonly List<Vehicle> _vehicles = new();
        public static Vehicle CreateVehicle(string type,string plateNo, List<DateTime> dates)
        {
            var vehicle = _vehicles.FirstOrDefault(v => v.PlateNo == plateNo);
            if (vehicle != null) return vehicle;
            vehicle = type.ToLower() switch
            {
                "car" => new Car(dates, plateNo, ""),
                "motorbike" => new Motorbike(dates, plateNo, ""),
                _ => throw new NotImplementedException(),
            };
            ;
           _vehicles.Add(vehicle);
           return vehicle;
        }
    }
}
