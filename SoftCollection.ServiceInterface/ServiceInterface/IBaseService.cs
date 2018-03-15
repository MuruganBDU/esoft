using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCollection.ServiceInterface.ServiceInterface
{
    public interface IBaseService<T>
    {
        T Create(T item);
        bool Update(T item);
    }
}
