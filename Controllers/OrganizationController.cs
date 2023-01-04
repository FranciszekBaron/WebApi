using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.DTO_s;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IRepositoryWrapper _service;

        public OrganizationController(IRepositoryWrapper service)
        {
            _service = service;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok((await _service.organization.GetAll().ToListAsync()).Select(e => new OrganizationGet
                {
                    oID = e.oID,
                    oName = e.oName,
                    oDomain = e.oDomain,
                })
            );

        }

    }
}
