using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplication1.Models.DTO_s;

namespace WebApplication1.Services
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly OrganDbContext _dbContext;
        private IMemberService _member;
        private IOrganizationService _organization;
        private ITeamService _team;
        private IMemberShipService _membership;
       
        public RepositoryWrapper(OrganDbContext dbContext) {
           _dbContext = dbContext;
        }


        public IMemberShipService membership
        {
            get
            {
                if(_membership is null)
                {
                    _membership = new MemberShipService(_dbContext);

                }
                return _membership;
            }
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

        public async Task addTwo(MemberPut body, int teamID)
        {
            var member = new Member
            {
                oID = body.oID,
                memberName = body.memberName,
                memberSurname = body.memberSurname,
                memberNickname = body.memberNickname,

            };

            var membership = new Membership
            {
                memberID = body.oID,
                teamID = teamID,
                MembershipDate = DateTime.Now
            };

            _dbContext.Add(member);
             _dbContext.Add(membership);
            await _dbContext.SaveChangesAsync();
        }

        

        public Task BeginTransactionAsync()
        {
            
            return _dbContext.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            await _dbContext.Database.CommitTransactionAsync();
        }

        public async Task Dispose()
        {
            await _dbContext.DisposeAsync();
        }

        public async Task RollbackTransactionAsync()
        {
            await _dbContext.Database.RollbackTransactionAsync();
        }

        public async Task saveAync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public Task TransactionScope()
        {
            throw new NotImplementedException();
        }
    }
}
