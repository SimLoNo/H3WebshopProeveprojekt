using H3WebshopProeveprojekt.Api.Database;
using H3WebshopProeveprojekt.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> InsertNewCategory();
        Task<Category> UpdateCategory(int categoryId, Category category);
        Task<Category> DeleteCategory(int id);
    }
    public class CategoryRepository : ICategoryRepository
    {
        private readonly H3WebshopProeveprojektContext _context;
        public CategoryRepository(H3WebshopProeveprojektContext context)
        {
            _context = context;
        }
        public async Task<Category> DeleteCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Category
                .Include(x => x.Products)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<Category> InsertNewCategory()
        {
            throw new System.NotImplementedException();
        }

        public async Task<Category> UpdateCategory(int categoryId, Category category)
        {
            throw new System.NotImplementedException();
        }
    }
}
