using Core.Interfaces;
using Infrastructure.Data.Repositories;

namespace Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly PlutoContext _context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public UnitOfWork(PlutoContext context)
        {
            _context = context;
            Issues = new IssueRepository(_context);
        }

        public IAuthorRepository issues => throw new NotImplementedException();
        public IIssueRepository Issues { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public async Task<int> CompleteAsync() => await _context.SaveChangesAsync();


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}