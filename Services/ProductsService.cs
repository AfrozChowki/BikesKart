using BikesKart.Models;
using BikesKart.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BikesKart.Services
{
    public class ProductsService
    {
        private readonly ProductsRepository _productsRepository;
        private readonly BrandsRepository _brandsRepository;
        private readonly CategoriesRepository _categoriesRepository;

        public ProductsService(ProductsRepository productsRepository, BrandsRepository brandsRepository, CategoriesRepository categoriesRepository)
        {
            _productsRepository = productsRepository;
            _brandsRepository = brandsRepository;
            _categoriesRepository = categoriesRepository;
        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            var products = await _productsRepository.GetProducts();

            var brands = await _brandsRepository.GetBrands();
            List<Brand> brandsList = brands.ToList();

            var categories = await _categoriesRepository.GetCategories();
            List<Category> categoriesList = categories.ToList();

            foreach (var product in products.ToList())
            {
                product.Brand = brandsList.FirstOrDefault(b => b.BrandId == product.BrandId);
                product.Category = categoriesList.FirstOrDefault(c => c.CategoryId == product.CategoryId);
            }

            return products;
        }
    }
}
