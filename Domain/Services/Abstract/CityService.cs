using Congestion_tax_calculator_UI.Services;
using Domain.Entities.Abstract;
using Infrastructure.Data.Repositories;

namespace Domain.Services.Abstract
{
    public class CityService
    {
        private readonly string _cityName;
        private readonly CityRepository _repo;
        public CityService(string cityName)
        {
            _cityName = cityName;
            _repo = new CityRepository();

        }
        public decimal? CalcTax(string vehicleType,string plateNo,  List<DateTime> entriesTimes)
        {
            Vehicle vehicle = VehicleFactory.CreateVehicle(vehicleType, plateNo, entriesTimes);
            City? city = _repo.Get(_cityName);

            decimal? tax = city?.CalcTax(vehicle);
            return tax;
        }
    }
}
