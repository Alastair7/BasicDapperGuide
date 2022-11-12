using Basic.Dapper.Tutorial.ProjectService.Entities;
using Dapper;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace Basic.Dapper.Tutorial.ProjectService.Repository.ProjectRepository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly string connectionString;

        public ProjectRepository()
        {
            connectionString = Environment.GetEnvironmentVariable("Test");
        }



        public async Task<List<ProjectEntity>> GetProjects()
        {
            List<ProjectEntity> result = new ();

            return await Task.Run(() => 
            {
                using SqlConnection connection = new (connectionString);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var transaction = connection.BeginTransaction();
                try
                {
                    var sql = "SELECT * FROM ProjectTableName";
                    var result = connection.Query<ProjectEntity>(sql).ToList();
                    transaction.Commit();

                } 
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    transaction.Rollback();
                }


                return result;
            });
        }

        public async Task<ProjectEntity> GetProjectById(int projectId)
        {
            ProjectEntity result = null;

            #pragma warning disable CS8603 // Possible null reference return.
            return await Task.Run(() =>
            {
                using SqlConnection connection = new (connectionString);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                try
                {
                    var sql = "SELECT * FROM ProjectTableName WHERE ProjectId = @projectId";
                    var result = connection.QueryFirst<ProjectEntity>(sql, new { projectId });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                return result;
            });
            #pragma warning restore CS8603 // Possible null reference return.
        }

        public async Task<int> InsertProject(ProjectEntity project)
        {
            int result = 0;

            return await Task.Run(() =>
            {
                using SqlConnection connection = new(connectionString);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var transaction = connection.BeginTransaction();

                try
                {
                    var sql = "INSERT INTO ProjectTableName (ProjectName, ProjectMemberId) VALUES(@ProjectName, @ProjectMemberId)";
                    var result = connection.Execute(sql, project, transaction: transaction);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    transaction.Rollback();
                }

                return result;
            });
        }

        public Task<int> UpdateProject(ProjectEntity project)
        {
            return Task.Run(() =>
            {
                using SqlConnection connection = new(connectionString);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }


                var sql = "UPDATE ProjectTableName SET ProjectName = @ProjectName, ProjectMemberId = @ProjectMemberId";
                var result = connection.Execute(sql, project);

                return result;
            });
        }

        public Task<int> DeleteProject(int projectId)
        {
            return Task.Run(() =>
            {
                using SqlConnection connection = new(connectionString);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }


                var sql = "DELETE FROM ProjectTableName WHERE ProjectId = @projectId";
                var result = connection.Execute(sql, new { projectId });

                return result;
            });
        }
    }
}
