using MyDDDApp.Application.dto;
using MyDDDApp.Domain.Entities;
using MyDDDApp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDDDApp.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public async Task AddAsync(ProductDto dto)
        {
            var product = new Product(dto.Name, dto.Price);
            await productRepository.AddAsync(product);
        }

        public async Task<List<ProductDto>> GetAllAsync()
        {
            var products = await productRepository.getAllAsync();
            return products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Price = p.Price,
            }).ToList();
        }

        public async Task<ProductDto> GetByIdAsync(Guid id)
        {
            var product = await productRepository.GetByIdAsync(id);
            return new ProductDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }
    }
}
