using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.DTO_s;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IRepositoryWrapper _service;

        public MemberController(IRepositoryWrapper service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok((await _service.member.GetAll().ToListAsync()).Select(e => new MemberGet
            {
                memberID = e.memberID,
                oID = e.oID,
                memberName = e.memberName,
                memberSurname = e.memberSurname,
                memberNickname = e.memberNickname
            }
            ));
        }

        [HttpPut("id")]
        public async Task<IActionResult> Edit(int id,MemberPut body)
        {
            var member = await _service.member.GetByIdAsync(id);

            if (member is null)
                return BadRequest();

            member.oID = body.oID;
            member.memberName = body.memberName;
            member.memberSurname = body.memberSurname;
            member.memberNickname = body.memberNickname;

            _service.member.UpdateMember(member);
            await _service.saveAync();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add(MemberPut body)
        {
            var member = new Member
            {
                oID = body.oID,
                memberName = body.memberName,
                memberSurname = body.memberSurname,
                memberNickname = body.memberNickname,

            };


            _service.member.CreateMember(member);
            await _service.saveAync();
            return (Ok("Member created"));
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Delete(int id)
        {
            var member = await _service.member.GetByIdAsync(id);

            if(member is null)
                return BadRequest();

            _service.member.DeleteMember(member);
            await _service.saveAync();

            return Ok("Member Deleted");
        }


    }
}
