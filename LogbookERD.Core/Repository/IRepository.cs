namespace LogbookERD.Core.Repository
{
    public interface IRepository<T>
    {
        void Add(T item);

        void Remove(Guid id);

        void Updata(T item);

        IQueryable<T> GetQueryableAll();
    }
}
