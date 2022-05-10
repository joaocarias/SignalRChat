namespace SignalRChat.Data.Repositories
{
    public interface IRepositoy<T> where T : class
    {
        void Create(T entity);
        void Update(Guid id, T entity);
        IEnumerable<T> GetAll();
        T Get(Guid id);
    }
}