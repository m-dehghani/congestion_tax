using Infrastructure.Data.Abstract;
using Domain.Entities.Abstract;
using Domain.Enums;

namespace Infrastructure.Data.Repositories
{
    public class CityRepository: IRepository
    {
        readonly string CityFileName = "cities.csv";
        static readonly List<City>? _cities = new();
        DateTime _lastUpdateOfTheCitiesFile;
        public CityRepository()
        {
            // Read city information from CSV file
            try
            {
                if (File.GetLastWriteTime(CityFileName) > _lastUpdateOfTheCitiesFile || !_cities.Any())
                {
                    using var reader = new StreamReader(CityFileName);
                    List<string> listA = new();
                    List<string> listB = new();
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line?.Split(';');
                        if (values?.Length > 0)
                        {
                            listA.Add(values[0]);
                            listB.Add(values[1]);
                        }
                    }

                }
            }
            catch { }

            //just for testing; It should read from file or DB.
            _cities?.Add(new City()
            {
                CityName = "Guthenberg",
                TollFreeDates = new List<DateTime>(),
                TollFreeVehicles = TollFreeVehicles.Diplomat | TollFreeVehicles.Emergency | TollFreeVehicles.Foreign |
                                   TollFreeVehicles.Military | TollFreeVehicles.Motorcycle | TollFreeVehicles.Tractor,

                MaxTotalfeePerDay = 60,
                TaxLineItems = new List<CityTaxLineItem>()
            {
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(6, 0, 0),
                    End = new TimeOnly(06, 29, 0),
                    TaxAmount = 8
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(6, 30, 0),
                    End = new TimeOnly(06, 59, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(7, 0, 0),
                    End = new TimeOnly(7, 59, 0),
                    TaxAmount = 18
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(8, 0, 0),
                    End = new TimeOnly(8, 29, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(8, 30, 0),
                    End = new TimeOnly(14, 59, 0),
                    TaxAmount = 8
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(15, 0, 0),
                    End = new TimeOnly(15, 29, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(15, 30, 0),
                    End = new TimeOnly(16, 59, 0),
                    TaxAmount = 18
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(17, 0, 0),
                    End = new TimeOnly(17, 29, 0),
                    TaxAmount = 13
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(18, 0, 0),
                    End = new TimeOnly(18, 29, 0),
                    TaxAmount = 8
                },
                new CityTaxLineItem()
                {
                    Start = new TimeOnly(18, 30, 0),
                    End = new TimeOnly(05, 59, 0),
                    TaxAmount = 0
                },

            }
            });
        }
        
        public static Entity? Get(string name)
        {
            var city = _cities?.FirstOrDefault(c => c.CityName == name);
            return city ?? throw new Exception("There is no city with this name in database!");
        }

        public void Update(Entity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Entity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(Entity entity)
        {
            throw new NotImplementedException();
        }
    }
}
