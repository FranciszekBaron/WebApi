using System.Linq.Expressions;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public interface IOrganizationService : IRepositoryBase<Organization>
    {
        public void CreateOrganization(Organization entity);

        public void DeleteOrganization(Organization entity);

        public Task<Organization> GetByIdAsync(int id);


        public void UpdateOrganizatio(Organization entity);
        
    }
}
