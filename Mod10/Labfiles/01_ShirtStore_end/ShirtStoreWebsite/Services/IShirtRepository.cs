using ShirtStoreWebsite.Models;

namespace ShirtStoreWebsite.Services
{
    public interface IShirtRepository
    {
        IEnumerable<Shirt> GetShirts();
        bool AddShirt(Shirt shirt);
        bool RemoveShirt(int id);
    }
}
