using Basic.Dapper.Tutorial.ProjectService.Entities;

namespace Basic.Dapper.Tutorial.ProjectServices.Business.ProjectService
{
    public interface IProjectService
    {
        Task<List<ProjectEntity>> GetAllProjects();

        Task<ProjectEntity> GetProject(int projectId);

        Task<bool> InsertProject(ProjectEntity project); 

        Task<bool> UpdateProject(ProjectEntity project);

        Task<bool> DeleteProject(int projectId);
    }
}
