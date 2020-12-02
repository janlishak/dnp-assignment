using Ass1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ass1.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}
