using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectsApi.Data;

namespace ProjectsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {

        private readonly ProjectContext projectContext;

        public ProjectController(ProjectContext projectContext) 
        {
            this.projectContext = projectContext; 
        }



    }
}
