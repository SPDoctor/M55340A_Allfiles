using ButterfliesShop.Models;

namespace ButterfliesShop.Services
{
    public interface IButterfliesQuantityService
    {
        int? GetButterflyFamilyQuantity(Family family);
        void AddButterfliesQuantityData(Butterfly butterfly);
    }
}
