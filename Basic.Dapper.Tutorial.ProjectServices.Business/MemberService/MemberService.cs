using Basic.Dapper.Tutorial.ProjectService.Entities;
using Basic.Dapper.Tutorial.ProjectService.Repository.MemberRepository;

namespace Basic.Dapper.Tutorial.ProjectServices.Business.MemberService
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        public async Task<int> InsertMember(MemberEntity member)
        {
            return  await memberRepository.InsertMember(member);
        }

        public async Task<int> UpdateMember(MemberEntity member)
        {
            return await memberRepository.UpdateMember(member);
        }

        public Task<int> DeleteMember(int memberId)
        {
            return memberRepository.DeleteMember(memberId);
        }

        public Task<List<MemberEntity>> GetMembers()
        {
            return memberRepository.GetMembers();
        }

        public Task<MemberEntity> GetMemberById(int memberId)
        {
            return memberRepository.GetMemberById(memberId);
        }



    }
}
