using AlkemyChallenge.Domain.Commands;

namespace AlkemyChallenge.AccessData.Commands
{
    public class GenericsRepository : IGenericsRepository
    {
        private readonly APIDbContext _context;
        public GenericsRepository(APIDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        public void Remove<T>(T entity) where T : class
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }
    }
}
