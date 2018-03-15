using SoftCollection.ServiceInterface.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftCollection.Data.Model.Master;
using SoftCollection.Repository.Repository;
using SoftCollection.RepositoryInterface.RepositoryInterface;

namespace SoftCollection.Service
{
    public class LoginService : BaseConnection<UserMaster>, ILoginService
    {
        public readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }
        public bool checkUserByPassword(string userName, string passWord)
        {
            try
            {
                return _loginRepository.checkUserByPassword(userName, passWord);
            }
            catch(Exception ex)
            {
                throw new Exception("User Not Found...", new Exception(ex.ToString()));
            }
        }

        public UserMaster Create(UserMaster item)
        {
            throw new NotImplementedException();
        }

        public bool Update(UserMaster item)
        {
            throw new NotImplementedException();
        }
    }
}
