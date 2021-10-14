using marketing_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.Interfaces
{
    public interface IUserRepository : IRepository<AspNetUsers>
    {
        Task<IEnumerable<AspNetUsers>> GetAllUsers();
        AspNetUsers GetUser(string id);
    }
}
