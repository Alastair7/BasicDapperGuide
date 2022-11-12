using Basic.Dapper.Tutorial.ProjectService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic.Dapper.Tutorial.ProjectService.Repository.ProjectRepository
{
    public interface IProjectRepository
    {
        Task<List<ProjectEntity>> GetProjects();

        Task<ProjectEntity> GetProjectById(int projectId);

        Task<int> InsertProject(ProjectEntity project);

        Task<int> UpdateProject(ProjectEntity project);

        Task<int> DeleteProject(int projectId);
    }
}
