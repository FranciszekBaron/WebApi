using System.Linq.Expressions;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface ITeamService : IRepositoryBase<Team>
    {
        public Task<Team> GetById(int id);

        void CreateTeam(Team team);
        void DeleteTeam(Team team);
        void UpdateTeam(Team team);
    }
}
