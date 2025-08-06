using AutoMapper;
using ProductApp.Application.Features.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductApp.Application.Mapping
{
    public class GeneralMapping: Profile
    {
        public GeneralMapping()
        {
            CreateMap<Domain.Entities.Product, dto.ProductViewDto>()
                .ReverseMap();

            CreateMap<Domain.Entities.Product, CreateProductCommand>()
                .ReverseMap();
        }
    }
}
