using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DTO_s;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeamController : ControllerBase
    {

        private readonly IRepositoryWrapper _service;
        public TeamController(IRepositoryWrapper service) {
            _service= service;
        }

        [HttpGet]  

        public async Task<IActionResult> GetAll()
        {
            return Ok((await _service.team.GetAll().ToListAsync()).Select(e => new TeamGet
            {
                teamID = e.teamID,
                teamName = e.teamName,
                teamDescription = e.teamDescription
            }
            ));
        }


        [HttpGet("id")]
        public async Task<IActionResult> GetById(int id)
        {
            var team = await _service.team.GetById(id);
            if (team is null)
                return BadRequest();

            return Ok(new TeamGet
            {
                teamID = team.teamID,
                oID = team.teamID,
                teamName = team.teamName,
                teamDescription = team.teamDescription,
                members = team.Memberships.Select(e=> 
                new TeamGetMembers
                {
                    memberID = e.memberID,
                    name = e.Member.memberName,
                }).OrderBy(e=>e.membershipDate).ToList()
                
            });
        }
    }
}
