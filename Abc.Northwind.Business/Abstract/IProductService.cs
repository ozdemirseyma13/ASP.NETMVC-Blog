using System;
using System.Collections.Generic;
using Abc.Core.DataAccess.EntityFramework;
using Abc.Core.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abc.Northwind.Entitites.Concrete;

namespace Abc.Northwind.Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int CategoryId);
        void Add(Product product);
        void Update(Product product);
        Product GetById(int productId);
        void Delete(Product product);
    }


}
