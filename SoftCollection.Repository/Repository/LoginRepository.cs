using SoftCollection.Data.Model.Master;
using SoftCollection.RepositoryInterface.RepositoryInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftCollection.Repository.Repository
{
    public class LoginRepository : BaseConnection<UserMaster>, ILoginRepository
    {
        public bool checkUserByPassword(string userName, string passWord)
        {
            try
            {
                var userExist = (from user in dbcontext.userMaster where (user.UserName == userName && user.Password == passWord) select user).FirstOrDefault();
                if (userExist == null)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch (Exception ex)
            {

                throw new Exception("E0001", new Exception(ex.Message));
            }            
        }
    }
}
