using marketing_web.Interfaces;
using marketing_web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.Repositories
{
    public class UserRepository : Repository<AspNetUsers>, IUserRepository
    {
        private DigitalPlusContext _dbContext { get { return _context as DigitalPlusContext; } }

        public UserRepository(DigitalPlusContext dbContext) : base(dbContext)
        {
        }
        public async Task<IEnumerable<AspNetUsers>> GetAllUsers()
        {
            return await _dbContext.AspNetUsers.OrderBy(t => t.Email).ToListAsync();
        }

        public AspNetUsers GetUser(string id)
        {
            return _dbContext.AspNetUsers.Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
