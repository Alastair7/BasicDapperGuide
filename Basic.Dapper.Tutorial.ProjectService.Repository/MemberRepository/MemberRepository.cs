using Basic.Dapper.Tutorial.ProjectService.Entities;
using Microsoft.Data.SqlClient;
using System.Data;
using Dapper;
using System.Diagnostics.Metrics;

namespace Basic.Dapper.Tutorial.ProjectService.Repository.MemberRepository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly string connectionString = string.Empty;
        public MemberRepository()
        {
            connectionString = "Server=localhost\\SQLEXPRESS;Database=master;Trusted_Connection=True;";
        }

        public async Task<List<MemberEntity>> GetMembers()
        {
            List<MemberEntity> membersList = new ();

            return await Task.Run(() =>
            {
                using SqlConnection connection = new(connectionString);

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                try
                {
                    var sql = "SELECT * FROM [ProjectsDB].[dbo].[Member]";
                    membersList = connection.Query<MemberEntity>(sql).ToList();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }


                return membersList;
            });
        }

        public async Task<MemberEntity> GetMemberById(int memberId)
        {
            MemberEntity member = new ();

            return await Task.Run(() =>
            {
                using SqlConnection connection = new(connectionString);

                try
                {
                    var sql = "SELECT * FROM [ProjectsDB].[dbo].[Member] WHERE MemberId = @memberId";
                    member = connection.QueryFirstOrDefault<MemberEntity>(sql, new { memberId });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return member;
            });
        }

        public async Task<int> InsertMember(MemberEntity member)
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
                    var sql = "INSERT INTO [ProjectsDB].[dbo].[Member] (MemberName, MemberRole) VALUES (@MemberName, @MemberRole)";
                    result = connection.Execute(sql, member, transaction: transaction);
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

        public async Task<int> UpdateMember(MemberEntity member)
        {
            int result = 0;
            return await Task.Run(() =>
            {
                using SqlConnection connection = new(connectionString);

                try
                {
                    var sql = "UPDATE [ProjectsDB].[dbo].[Member] SET MemberName = @MemberName, MemberRole = @MemberRole WHERE MemberId = @MemberId";
                    result = connection.Execute(sql, member);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return result;
            });
        }

        public async Task<int> DeleteMember(int memberId)

        {
            int result = 0;
            return await Task.Run(() =>
            {
                using SqlConnection connection = new(connectionString);

                try
                {
                    var sql = "DELETE FROM [ProjectsDB].[dbo].[Member] WHERE MemberId = @memberId";
                    result = connection.Execute(sql, new { memberId = memberId, test = memberId });
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                return result;
            });
        }
    }
}
