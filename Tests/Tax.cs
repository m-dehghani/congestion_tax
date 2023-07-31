using Domain.Services.Abstract;

namespace Tests
{
    public class TaxTests
    {
        private readonly CityService cityService;
        public TaxTests()
        {
            cityService = new CityService("Guthenberg");
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void CalcSuccessfully(string vehicleType, string plateNo, List<DateTime> dates, decimal expected)
        {
            var tax = cityService.CalcTax(vehicleType,plateNo,dates);
            Assert.Equal(expected, tax);
        }

       public static IEnumerable<object[]> Data =>
       new List<object[]>
       {
            new object[] { "Car", "123456", new List<DateTime>() { new DateTime(2013, 01, 14, 21, 00, 00), new DateTime(2013, 01, 15, 21, 00, 00) }, 60 },
            new object[]  {"Car","124575", new List<DateTime>() { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 07, 07, 59, 00) }, 39 },
            new object[]  {"Car","124574", new List<DateTime>() { new DateTime(2013, 02, 07, 06, 23, 27), new DateTime(2013, 02, 07, 15, 27, 00) } , 60 },
            new object[]  {"Car","124573", new List<DateTime>() { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 09, 18, 00, 00) }, 180 },
            new object[]  {"Car","12457387", new List<DateTime>() { new DateTime(2013, 02, 07, 8, 00, 00), new DateTime(2013, 02, 07, 16, 59, 00) }, 52 },
            new object[]  {"Car","126884", new List<DateTime>() { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 09, 06, 00, 00) }, 120 },
            new object[]  {"Car","187584", new List<DateTime>() { new DateTime(2013, 02, 07, 06, 00, 00), new DateTime(2013, 02, 09, 07, 00, 00) }, 141 },
       };
    }
}