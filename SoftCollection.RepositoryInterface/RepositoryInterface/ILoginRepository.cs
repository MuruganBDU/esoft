using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCollection.RepositoryInterface.RepositoryInterface
{
    public interface ILoginRepository
    {
        bool checkUserByPassword(string userName, string passWord);
    }
}
