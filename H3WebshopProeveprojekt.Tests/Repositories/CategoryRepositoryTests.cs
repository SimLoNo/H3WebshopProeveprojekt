using H3WebshopProeveprojekt.Api.Database;
using H3WebshopProeveprojekt.Api.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace H3WebshopProeveprojekt.Tests.Repositories
{
    public class CategoryRepositoryTests
    {
        private readonly DbContextOptions<H3WebshopProeveprojektContext> _options;
        private readonly H3WebshopProeveprojektContext _context;
        private readonly CategoryRepository _categoryRepository;
        public CategoryRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<H3WebshopProeveprojektContext>()
                .UseInMemoryDatabase(databaseName: "H3WebshopProeveprojektCategories")
                .Options;

            _context = new(_options);

            _categoryRepository = new(_context);
        }
        [Fact]
        public async void GetAllCategories_ShouldReturnListOfCategories_WHenCategoriesExists()
        {

        }
    }
}
