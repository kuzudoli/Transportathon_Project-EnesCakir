namespace Transportathon_Project_EnesCakir.Repository.Interfaces
{
    public interface IUnitOfWork 
    {
        Task CommitAsync();
        void Commit();
    }
}
