using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class MemberShipService : RepositoryBase<Membership>, IMemberShipService
    {
        private readonly OrganDbContext _dbContext;

        public MemberShipService(OrganDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        

        public void CreateMembership(Membership membership)
        {
            Create(membership);
        }

        public void DeleteMembership(Membership membership)
        {
            Delete(membership);
        }

        public Task<Membership> GetByIdAsync(int id)
        {
            return GetByCondition(e => e.memberID == id).FirstOrDefaultAsync();
        }

        public void UpdateMembership(Membership membership)
        {
            Update(membership);
        }
    }
}
