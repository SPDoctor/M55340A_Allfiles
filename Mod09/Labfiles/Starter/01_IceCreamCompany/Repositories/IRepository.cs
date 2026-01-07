using IceCreamCompany.Models;

namespace IceCreamCompany.Repositories
{
    public interface IRepository
    {
        IEnumerable<IceCream> GetIceCreamFlavors();
        IceCream GetIceCreamFlavorById(int id);
        void BuyIceCreamFlavor(Customer customer);
    }
}
