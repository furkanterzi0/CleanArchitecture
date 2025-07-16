using AutoMapper;
using MediatR;
using ProductApp.Application.Interfaces.Repository;
using ProductApp.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Features.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<ServiceResponse<Guid>>
    {
        public String Name { get; set; }
        public decimal Value { get; set; }
        public int Quantity { get; set; }


        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>
        {
            IProductRepository productRepository;
            private readonly IMapper mapper;
            public CreateProductCommandHandler(IProductRepository productRepository, IMapper mapper)
            {
                this.productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
                this.mapper = mapper;
            }

            async Task<ServiceResponse<Guid>> IRequestHandler<CreateProductCommand, ServiceResponse<Guid>>.Handle(CreateProductCommand request, CancellationToken cancellationToken)
            {
                var product = mapper.Map<Domain.Entities.Product>(request);
                await productRepository.AddAsync(product);

                return new ServiceResponse<Guid>(product.Id);
            }
        }
    }
}
