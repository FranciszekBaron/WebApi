namespace WebApplication1.Services
{
    public interface IRepositoryWrapper
    {
        IMemberService member { get; }

        IOrganizationService organization { get; }

        ITeamService team { get; }
        Task saveAync();

    }
}
