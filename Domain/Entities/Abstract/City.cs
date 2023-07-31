using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Services.Abstract;
using Domain.Services.Concrete;

namespace Domain.Entities.Abstract
{

    public class City : Entity
    {
        private ICalculator _taxCalculator;

        public City()
        {
            _taxCalculator = new NewTaxCalculator(this);
        }
        public string CityName { get; set; }

        public List<DateTime> TollFreeDates { get; set; } = new List<DateTime>();
       
        public TollFreeVehicles TollFreeVehicles { get; set; }

        //These can be read from file or DB
        public List<CityTaxLineItem> TaxLineItems { get; set; } = new List<CityTaxLineItem>();

        public decimal MaxTotalfeePerDay { get; set; }

        public bool IsTollFreeDate(DateTime date) => TollFreeDates.Contains(date);

        public bool IsTollFreeVehicle(Vehicle vehicle)
        {
            var names = Enum.GetNames(TollFreeVehicles.GetType());
            var res =  names.Contains(vehicle.GetVehicleType());
            return res;
        }

        public decimal CalcTax(Vehicle vehicle)
        {
            return _taxCalculator.GetTax(vehicle);
        }
    }
}
