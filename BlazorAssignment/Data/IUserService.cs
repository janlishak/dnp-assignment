using BlazorAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAssignment.Data
{
    public interface IUserService
    {
        User ValidateUser(string userName, string password);
    }
}
