using Transportathon_Project_EnesCakir.Repository.Interfaces;

namespace Transportathon_Project_EnesCakir.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        protected AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
