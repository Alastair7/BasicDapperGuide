using Basic.Dapper.Tutorial.ProjectService.Entities;

namespace Basic.Dapper.Tutorial.ProjectService.Repository.MemberRepository
{
    public interface IMemberRepository
    {
        Task<int> InsertMember(MemberEntity member);

        Task<int> UpdateMember(MemberEntity member);

        Task<int> DeleteMember(int memberId);

        Task<List<MemberEntity>> GetMembers();

        Task<MemberEntity> GetMemberById(int memberId);
    }
}
