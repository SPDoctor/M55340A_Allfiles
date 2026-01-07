using ButterfliesShop.Models;

namespace ButterfliesShop.Services
{
    public interface IDataService
    {
        List<Butterfly> ButterfliesList { get; set; }
        List<Butterfly> ButterfliesInitializeData();
        Butterfly GetButterflyById(int? id);
        void AddButterfly(Butterfly butterfly);
    }
}
