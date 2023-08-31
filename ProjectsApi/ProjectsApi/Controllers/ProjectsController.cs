using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProjectsApi.Data;
using ProjectsApi.Models;
namespace ProjectsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectContext projectContext;

        public ProjectsController(ProjectContext projectContext)
        {
            this.projectContext = projectContext;
        }

        // GET: api/Projects
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Project>>> GetProjects() 
        {
            if(projectContext == null)
                return NotFound();

            return await projectContext.Projects.ToListAsync(); 
        
        }


    }
}
