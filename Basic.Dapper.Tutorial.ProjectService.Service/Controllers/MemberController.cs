using Basic.Dapper.Tutorial.ProjectService.Entities;
using Basic.Dapper.Tutorial.ProjectServices.Business.MemberService;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Dapper.Tutorial.ProjectService.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService memberService;

        public MemberController(IMemberService memberService)
        {
            this.memberService = memberService;
        }

        [HttpGet("GetMembers")]
        public async Task<IActionResult> GetMembers()
        {
            var result = await memberService.GetMembers();

            return Ok(result);
        }

        [HttpGet("GetMember")]
        public async Task<IActionResult> GetMember(int memberId)
        {
            var result = await memberService.GetMemberById(memberId);

            return Ok(result);
        }

        [HttpPost("InsertMember")]
        public async Task<IActionResult> InsertMember([FromBody] MemberEntity member)
        {
            int result = await memberService.InsertMember(member);

            return Ok(result);
        }

        [HttpPut("UpdateMember")]
        public async Task<IActionResult> UpdateMember([FromBody] MemberEntity member)
        {
            int result = await memberService.UpdateMember(member);

            return Ok(result);
        }

        [HttpDelete("DeleteMember")]
        public async Task<IActionResult> DeleteMember([FromQuery] int memberId)
        {
            var result = await memberService.DeleteMember(memberId);

            return Ok(result);
        }
    }
}
