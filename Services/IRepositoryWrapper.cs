using WebApplication1.Models.DTO_s;

namespace WebApplication1.Services
{
    public interface IRepositoryWrapper
    {
        IMemberService member { get; }

        IOrganizationService organization { get; }

        ITeamService team { get; }

        IMemberShipService membership { get; }

        Task addTwo(MemberPut body,int teamID);
        
        Task saveAync();

        Task BeginTransactionAsync();

        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
        Task Dispose();

        Task TransactionScope();

    }
}
