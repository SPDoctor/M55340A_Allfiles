using ShirtStoreWebsite.Models;
using ShirtStoreWebsite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShirtStoreWebsite.Tests.FakeRepositories
{
    internal class FakeShirtRepository : IShirtRepository
    {
        public IEnumerable<Shirt> GetShirts()
        {
            return new List<Shirt>()
            {
                  new Shirt { Color = ShirtColor.Black, Size = ShirtSize.S, Price = 11F },
                  new Shirt { Color = ShirtColor.Gray, Size = ShirtSize.M, Price = 12F },
                  new Shirt { Color = ShirtColor.White, Size = ShirtSize.L, Price = 13F }
            };
        }

        public bool AddShirt(Shirt shirt)
        {
            return true;
        }

        public bool RemoveShirt(int id)
        {
            return true;
        }
    }
}
