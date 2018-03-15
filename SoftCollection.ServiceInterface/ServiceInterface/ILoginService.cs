using SoftCollection.Data.Model.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCollection.ServiceInterface.ServiceInterface
{
    public interface ILoginService : IBaseService<UserMaster>
    {
        bool checkUserByPassword(string userName, string passWord);
    }
}
