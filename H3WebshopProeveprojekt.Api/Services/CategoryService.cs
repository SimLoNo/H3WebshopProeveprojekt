using H3WebshopProeveprojekt.Api.Database.Entities;
using H3WebshopProeveprojekt.Api.DTO;
using H3WebshopProeveprojekt.Api.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace H3WebshopProeveprojekt.Api.Services
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponse>> GetAllCategories();
        public Task<CategoryResponse> GetCategoryById(int id);
        public Task<CategoryResponse> InsertNewCategory(CategoryRequest category);
        public Task<CategoryResponse> UpdateNewCategory(int id, CategoryRequest category);
        public Task<CategoryResponse> DeleteCategory(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly CategoryRepository _repository;

        public CategoryService(CategoryRepository repository)
        {
            _repository = repository;
        }
        public Task<CategoryResponse> DeleteCategory(int id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<List<CategoryResponse>> GetAllCategories()
        {
            List<Category> categories = await _repository.GetAllCategories();
            if (categories != null)
            {
                return categories.Select(category => MapCategoryToCategoryResponse(category)).ToList();
            }
            return null;
        }

        public Task<CategoryResponse> GetCategoryById(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryResponse> InsertNewCategory(CategoryRequest category)
        {
            throw new System.NotImplementedException();
        }

        public Task<CategoryResponse> UpdateNewCategory(int id, CategoryRequest category)
        {
            throw new System.NotImplementedException();
        }

        private static CategoryResponse MapCategoryToCategoryResponse(Category category)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Products = category.Products.Select(product => new CategoryProductResponse
                {
                    Id = category.Id,
                    Name = product.Name,
                    Price = product.Price,
                    DiscountPercentage = product.DiscountPercentage,
                    CategoryId = product.CategoryId,

                }).ToList()
            };
        }

        private static Category MapCategoryRequestToCategory(Category category)
        {
            return new Category
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
            };
        }
    }
}
