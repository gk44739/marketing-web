using marketing_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<AspNetUsers>> GetUsers();
        string GetUserId();
        string GetUserName();
        string GetUserEmail();
        string GetUserPhoneNumber();
        string GetUserFullName(string id);
        public string GetUsernameByUserId(string id);
    }
}
