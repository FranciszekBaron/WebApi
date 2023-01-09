using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IMemberShipService : IRepositoryBase<Membership>
    {
        public void CreateMembership(Membership membership);
        public void DeleteMembership(Membership membership);
        public void UpdateMembership(Membership membership);


        public Task<Membership> GetByIdAsync(int id);
    }
}
