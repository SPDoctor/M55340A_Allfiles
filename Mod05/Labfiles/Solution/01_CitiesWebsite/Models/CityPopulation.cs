namespace CitiesWebsite.Models
{
    public class CityPopulation
    {
        public int Year { get; }
        public int City { get; }
        public int Urban { get; }
        public int Metro { get; }

        public CityPopulation(int year, int city, int urban, int metro)
        {
            Year = year;
            City = city;
            Urban = urban;
            Metro = metro;
        }
    }
}
