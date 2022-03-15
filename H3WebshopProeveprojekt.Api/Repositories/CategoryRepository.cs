using H3WebshopProeveprojekt.Api.Database;
using H3WebshopProeveprojekt.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<Category> GetCategoryById(int id);
        Task<Category> InsertNewCategory(Category category);
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
            Category category = await _context.Category
                .Include(x => x.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category != null)
            {
                _context.Category.Remove(category);
                await _context.SaveChangesAsync();
            }
            return category;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _context.Category
                .Include(x => x.Products)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _context.Category
                .Include(x => x.Products)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Category> InsertNewCategory(Category category)
        {
            _context.Category.Add(category);
            await _context.SaveChangesAsync();
            int categoryId = category.Id;
            category.Products = await _context.Product
                .Where(x => x.CategoryId == categoryId)
                .ToListAsync();
            return category;
        }

        public async Task<Category> UpdateCategory(int categoryId, Category category)
        {
            Category updatedCategory = await _context.Category.FirstOrDefaultAsync(c => c.Id == categoryId);
            if (updatedCategory != null)
            {
                updatedCategory.CategoryName = category.CategoryName;
                await _context.SaveChangesAsync();
                updatedCategory.Products = await _context.Product
                    .Where(Product => Product.CategoryId == categoryId)
                    .ToListAsync();
            }
            return updatedCategory;
        }
    }
}
