using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Models;
using WebApplication1.Models.DTO_s;
using Microsoft.EntityFrameworkCore.Storage;

namespace WebApplication1.Services
{
    public class MemberService : RepositoryBase<Member> , IMemberService
    {

        private readonly OrganDbContext _dbContext;

        public MemberService(OrganDbContext dbContext) : base(dbContext)
        {
             _dbContext = dbContext;
        }

        public Task<Member> addToTeam(int memberID, int teamID)
        {
            throw new NotImplementedException();
        }

        public  Task<Member> addWithTeam(Member member, Team team)
        {
            throw new NotImplementedException();
        }

        

      
        public void CreateMember(Member member)
        {
            Create(member);
        }
        
        public void DeleteMember(Member member)
        {
            Delete(member);
        }

       
        public Task<Member> GetByIdAsync(int id)
        {
            return GetByCondition(e => e.oID == id).FirstOrDefaultAsync();
        }

        public void UpdateMember(Member member)
        {
            Update(member);
        }



        


        

  

   
    }
}
