using StoreApp.Data.Contracts;
using StoreApp.Entities.Models;

namespace StoreApp.Data
{
    public class CategoryRepository : RepositoryBase<Category>,ICategoryRepository

    {
        public CategoryRepository(StoreAppContext context) : base(context)
        {

        }
    }
}
