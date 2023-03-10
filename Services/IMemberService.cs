using WebApplication1.Models;
using WebApplication1.Models.DTO_s;

namespace WebApplication1.Services
{
    public interface IMemberService : IRepositoryBase<Member>
    {
        public void CreateMember(Member member);
        public void DeleteMember(Member member);
        public void UpdateMember(Member member);

        public Task<Member> addToTeam(int memberID, int teamID);

        public Task<Member> addWithTeam(Member member, Team team);


        public Task<Member> GetByIdAsync(int id);

    }
}
