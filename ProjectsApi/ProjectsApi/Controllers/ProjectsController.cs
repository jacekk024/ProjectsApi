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
        // GET: api/Projects/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetMovie(int id) 
        {
            if (projectContext == null)
                return NotFound();

            var project = await projectContext.Projects.FindAsync(id);

            if (project == null)
            {
                return NotFound();
            }
            return project;
        }

        //POST: api/Projects
        public async Task<ActionResult<Project>> PostProject(Project project) 
        {
            if (project == null)
            {
                return BadRequest("Provided project is null.");
            }

            // Można dodać więcej walidacji dla 'project', np. sprawdzając czy pewne pola nie są puste.

            try
            {
                projectContext.Projects.Add(project);
                await projectContext.SaveChangesAsync();

                return CreatedAtAction(nameof(PostProject), new { id = project.Id }, project);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
