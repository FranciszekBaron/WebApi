using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class TeamService : RepositoryBase<Team>, ITeamService
    {

        private readonly OrganDbContext _dbcontext;
        public TeamService(OrganDbContext dbContext) : base(dbContext)
        {
            _dbcontext = dbContext;
        }

        public void CreateTeam(Team team)
        {
            Create(team);
        }

        public void DeleteTeam(Team team)
        {
            Delete(team);
        }

        public  Task<Team> GetById(int id)
        {
            return GetByCondition(e => e.teamID == id)
                    .Include(e => e.Organization)
                    .Include(e => e.Files)
                    .Include(e => e.Memberships)
                    .ThenInclude(e => e.Member)
                    .FirstOrDefaultAsync();
        }

        public void UpdateTeam(Team team)
        {
            Update(team);
        }
    }
}
