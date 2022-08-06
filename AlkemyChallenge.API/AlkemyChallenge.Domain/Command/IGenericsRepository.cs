
namespace AlkemyChallenge.Domain.Commands
{
    public interface IGenericsRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Remove<T>(T entity) where T : class;
    }
}
