using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abc.Northwind.Entitites.Concrete;
namespace Abc.Northwind.Business.Abstract
{
    public interface ICategoryService
    {

        List<Category> GetAll();
    }
}
