
namespace Repository.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ETContext _context;
        public UnitOfWork(ETContext context)
        {
            _context=context;
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
