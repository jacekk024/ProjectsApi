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
        private readonly MySQLProjectContext mySqlProjectContext;
        public ProjectsController(ProjectContext projectContext, MySQLProjectContext mySqlProjectContext)
        {
            this.projectContext = projectContext;
            this.mySqlProjectContext = mySqlProjectContext; 
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
        [HttpPost]
        public async Task<ActionResult<Project>> PostProject(Project project) 
        {
            if (project == null)
            {
                return BadRequest("Provided project is null.");
            }
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

        // PUT: api/Projects/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, Project project)
        {
            if (id != project.Id)
                return BadRequest();


            projectContext.Entry(project).State = EntityState.Modified;
            try
            {
                await projectContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovieExists(id))
                {
                    return NotFound();
                }
                else
                    throw;
            }
            return NoContent();
        }
        private bool MovieExists(int id)
        {
            return (projectContext.Projects?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            if (projectContext.Projects == null)
            {
                return NotFound();
            }
            var movie = await projectContext.Projects.FindAsync(id);
            if (movie == null)
            {
                return NotFound();
            }
            projectContext.Projects.Remove(movie);
            await projectContext.SaveChangesAsync();
            return NoContent();
        }
    }
}
