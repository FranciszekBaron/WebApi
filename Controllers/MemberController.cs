using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;
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

        [HttpPut("{id}")]
        public async Task<IActionResult> Edit(int id, MemberPut body)
        {
            var member = await _service.member.GetByIdAsync(id);


            if (member is null) {
                
                return BadRequest();
                
            }

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

            var organization = _service.organization.GetByIdAsync(body.oID);

            if (organization is null)
                throw new Exception("There is no organization with id" + body.oID);

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

        [HttpPost("{teamID}")]
        public async Task<IActionResult> addWithTeam(MemberPut body, int teamID)
        {
            

            var member = new Member
            {
                oID = body.oID,
                memberName = body.memberName,
                memberSurname = body.memberSurname,
                memberNickname = body.memberNickname,

            };

            _service.member.Create(member);
            await _service.saveAync();

            var membership = new Membership
            {
                memberID = member.memberID,
                teamID = teamID,
                MembershipDate = DateTime.Now
            };

            _service.membership.Create(membership);
            await _service.saveAync();

            return Ok();
                
         }
            

        [HttpPost("{memberID}/{teamID}")]
        public async Task<IActionResult> addToTeam(int memberID,int teamID)
        {
            var membership = new Membership
            {
                memberID = memberID,
                teamID = teamID,
                MembershipDate = DateTime.Now
            };
            
            
            await _service.saveAync();
            return Ok("Member added to the team");

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
            
                    
            

            
            
           
                
            
           





                

