using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abc.Northwind.Business.Abstract;
using Abc.Northwind.DataAccess.Abstract;
using Abc.Northwind.Entitites.Concrete;

namespace Abc.Northwind.Business.Concrete
{
    public class ProductManager : IProductService
    {
        private IProductDal _productdal;
        public ProductManager (IProductDal productDal)
        {
            _productdal = productDal;
        }
        public void Add(Product product)
        {
            _productdal.Add(product);

        }
        public void Delete(Product product)
        {
            _productdal.Delete(product);
        }
        public List<Product> GetAll()
        {
            return _productdal.GetList();
        }

        public List<Product> GetByCategory(int categoryId)
        {
            return _productdal.GetList(p=> p.CategoryId==categoryId|| categoryId==0);
        }

        public void Update(Product product)
        {
            _productdal.Update(product);
        }
        public Product GetById(int productId)
        {
            return _productdal.Get(p => p.ProductId == productId);
        }
    }
}
