using MediatR;
using OnionArchDemo.Application.Interfaces.Repositories;
using OnionArchDemo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionArchDemo.Application.Features.Commands
{
    public class CreateProductCommand: IRequest<int>
    {
        public int id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private readonly IProductRepository productRepository;

            public CreateProductCommandHandler(IProductRepository productRepository)
            {
                this.productRepository = productRepository;
            }
            public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = new Product
                {
                    Name = request.Name,
                    Price = request.Price
                };

                await productRepository.AddAsync(product);

                return product.Id;
            }
        }
    }
}
