using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abc.Northwind.DataAccess;
using Abc.Core.Entities;
using Abc.Core.DataAccess;

using Abc.Northwind.Entitites;
using Abc.Northwind.Entitites.Concrete;

namespace Abc.Northwind.DataAccess.Abstract
{
    public interface IProductDal : IEntityRepository<Product>
    {

    }

}
