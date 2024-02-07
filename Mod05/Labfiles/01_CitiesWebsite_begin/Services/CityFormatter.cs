namespace CitiesWebsite.Services
{
    public class CityFormatter : ICityFormatter
    {
        public string GetFormattedPopulation(int population)
        {
            return string.Format("{0:n0}", population);
        }
    }
}
