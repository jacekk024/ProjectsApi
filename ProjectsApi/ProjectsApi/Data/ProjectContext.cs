using Microsoft.EntityFrameworkCore;
using ProjectsApi.Models;

namespace ProjectsApi.Data
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }

    }
    public class MySQLProjectContext : DbContext
    {
        public MySQLProjectContext(DbContextOptions<MySQLProjectContext> options)
            : base(options)
        {

        }

        public DbSet<Project> Projects { get; set; }

    }
}
