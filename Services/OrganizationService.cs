using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class OrganizationService : RepositoryBase<Organization>, IOrganizationService
    {

        private readonly OrganDbContext _dbContext;
        public OrganizationService(OrganDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateOrganization(Organization entity)
        {
            Create(entity);
        }

        public void DeleteOrganization(Organization entity)
        {
            Delete(entity);
        }

        public Task<Organization> GetByIdAsync(int id)
        {
            return GetByCondition(e=>e.oID == id).FirstOrDefaultAsync();
        }

        public void UpdateOrganizatio(Organization entity)
        {
            Update(entity);
        }
    }
}
