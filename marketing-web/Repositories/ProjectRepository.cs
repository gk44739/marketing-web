using marketing_web.Interfaces;
using marketing_web.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace marketing_web.Repositories
{
    public class ProjectRepository : Repository<Projects>, IProjectRepository
    {
        private DigitalPlusContext _dbContext { get { return _context as DigitalPlusContext; } }

        public ProjectRepository(DigitalPlusContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Projects> GetAllProjects()
        {
            var model = _dbContext.Projects.Where(t => t.IsDeleted == false).OrderByDescending(t => t.InsertedDate);
            return model;
        }

        public Projects GetProjectById(int id)
        {
            var model = _dbContext.Projects.Include(t => t.ProjectFiles).Where(t => t.Id == id).FirstOrDefault();
            return model;
        }
    }
}
