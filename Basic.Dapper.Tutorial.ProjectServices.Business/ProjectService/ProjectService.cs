using Basic.Dapper.Tutorial.ProjectService.Entities;
using Basic.Dapper.Tutorial.ProjectService.Repository.ProjectRepository;

namespace Basic.Dapper.Tutorial.ProjectServices.Business.ProjectService
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            this.projectRepository = projectRepository;
        }

        public async Task<List<ProjectEntity>> GetAllProjects()
        {
            List<ProjectEntity> projects = await projectRepository.GetProjects();

            return projects;
        }

        public async Task<ProjectEntity> GetProject(int projectId)
        {
            ProjectEntity project = await projectRepository.GetProjectById(projectId);

            return project;
        }

        public async Task<bool> InsertProject(ProjectEntity project)
        {
            bool success;

            success = await projectRepository.InsertProject(project) > 0;

            return success;
        }

        public async Task<bool> UpdateProject(ProjectEntity project)
        {
            bool success;
            
            success = await projectRepository.UpdateProject(project) > 0;

            return success;
        }

        public async Task<bool> DeleteProject(int projectId)
        {
            bool success;

            success = await projectRepository.DeleteProject(projectId) > 0;

            return success;
        }
    }
}
