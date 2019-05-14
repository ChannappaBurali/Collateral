using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.IService
{
    public interface IUser
    {
       string ValidateUser(string userName, string password);
    }
}
