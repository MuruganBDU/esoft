using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCollection.RepositoryInterface.RepositoryInterface
{
    public interface IBaseRepository<T>
    {
        T Create(T item);
        bool Update(T item);
    }
}
