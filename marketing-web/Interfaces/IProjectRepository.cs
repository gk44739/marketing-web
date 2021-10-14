using marketing_web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.Interfaces
{
    public interface IProjectRepository : IRepository<Projects>
    {
        public IEnumerable<Projects> GetAllProjects();
        public Projects GetProjectById(int id);
    }
}
