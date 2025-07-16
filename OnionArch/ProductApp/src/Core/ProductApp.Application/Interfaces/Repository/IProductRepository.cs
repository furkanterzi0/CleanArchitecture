using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProductApp.Domain.Entities;


namespace ProductApp.Application.Interfaces.Repository
{
    public interface IProductRepository: IGenericRepositoryAsync<Product>
    {

    }
}
