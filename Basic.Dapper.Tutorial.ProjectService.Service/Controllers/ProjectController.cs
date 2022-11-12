using Basic.Dapper.Tutorial.ProjectService.Entities;
using Basic.Dapper.Tutorial.ProjectServices.Business.ProjectService;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Dapper.Tutorial.ProjectService.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService projectService;

        public ProjectController(IProjectService projectService)
        {
            this.projectService = projectService;
        }

        [HttpGet("GetProjects")]
        public async Task<IActionResult> GetProjects()
        {
            var result = await projectService.GetAllProjects();

            return Ok(result);
        }

        [HttpGet("GetProject")]
        public async Task<IActionResult> GetProject(int projectId)
        {
            var result = await projectService.GetProject(projectId);

            return Ok(result);
        }

        [HttpPost("InsertProject")]
        public async Task<IActionResult> InserProject([FromBody]ProjectEntity project)
        {
            var success = await projectService.InsertProject(project);

            return success ? Ok(success) : BadRequest();
        }

        [HttpPut("UpdateProject")]
        public async Task<IActionResult> UpdateProject([FromBody] ProjectEntity project)
        {
            var success = await projectService.UpdateProject(project);

            return success ? Ok(success) : BadRequest();
        }

        [HttpDelete("DeleteProject")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            var success = await projectService.DeleteProject(projectId);

            return success ? Ok(success) : BadRequest();
        }
    }
}
