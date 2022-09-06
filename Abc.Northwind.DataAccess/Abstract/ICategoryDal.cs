using Abc.Core.DataAccess;
using Abc.Northwind.Entitites.Concrete;

namespace Abc.Northwind.DataAccess.Abstract
{
    public interface ICategoryDal : IEntityRepository<Category>
    {
    }
}
