using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Models;
using WebApplication1.Models.DTO_s;

namespace WebApplication1.Services
{
    public class MemberService : RepositoryBase<Member> , IMemberService
    {

        private readonly OrganDbContext _dbContext;

        public MemberService(OrganDbContext dbContext) : base(dbContext)
        {
             _dbContext = dbContext;
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
            return GetByCondition(e => e.memberID == id).FirstOrDefaultAsync();
        }

        public void UpdateMember(Member member)
        {
            Update(member);
        }

       
        
    }
}
