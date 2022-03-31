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
        public Task<CategoryResponse> UpdateCategory(int id, CategoryRequest category);
        public Task<CategoryResponse> DeleteCategory(int id);
    }
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }
        public async Task<CategoryResponse> DeleteCategory(int id)
        {
            Category category = await _repository.DeleteCategory(id);
            if (category != null)
            {
                return MapCategoryToCategoryResponse(category);
            }
            return null;
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

        public async Task<CategoryResponse> GetCategoryById(int id)
        {
            Category category = await _repository.GetCategoryById(id);
            if (category != null)
            {
                return MapCategoryToCategoryResponse(category);
            }
            return null;
        }

        public async Task<CategoryResponse> InsertNewCategory(CategoryRequest category)
        {
            Category newCategory = MapCategoryRequestToCategory(category);
            Category insertedCategory = await _repository.InsertNewCategory(newCategory);
            if (insertedCategory != null)
            {
                return MapCategoryToCategoryResponse(insertedCategory);
            }
            return null;
        }

        public async Task<CategoryResponse> UpdateCategory(int id, CategoryRequest category)
        {
            Category updateCategory = MapCategoryRequestToCategory(category);
            Category newCategory = await _repository.UpdateCategory(id, updateCategory);
            if (newCategory != null)
            {
                return MapCategoryToCategoryResponse(newCategory);
            }
            return null;
        }

        private static CategoryResponse MapCategoryToCategoryResponse(Category category)
        {
            return new CategoryResponse
            {
                Id = category.Id,
                CategoryName = category.CategoryName,
                Products = category.Products.Select(product => new CategoryProductResponse
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price,
                    DiscountPercentage = product.DiscountPercentage,
                    CategoryId = product.CategoryId,
                    ProductImage = product.ProductImage,

                }).ToList()
            };
        }

        private static Category MapCategoryRequestToCategory(CategoryRequest category)
        {
            return new Category
            {
                CategoryName = category.CategoryName,
            };
        }
    }
}
