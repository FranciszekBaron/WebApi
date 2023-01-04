using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly OrganDbContext _dbContext;
        private IMemberService _member;
        private IOrganizationService _organization;
        private ITeamService _team;
        public RepositoryWrapper(OrganDbContext dbContext) {
           _dbContext = dbContext;
        }

        public IMemberService member
        {
            get
            {
                if (_member is null)
                {
                    _member = new MemberService(_dbContext);
                }
                return _member;
            }
        }

        public IOrganizationService organization
        {
            get
            {
                if(_organization is null)
                {
                    _organization= new OrganizationService(_dbContext);
                }
                return _organization;
            }
        }

        public ITeamService team
        {
            get
            {
                if(_team is null)
                {
                    _team= new TeamService(_dbContext);
                }
                return _team;
            }
        }

        

        public async Task saveAync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
