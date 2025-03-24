using LogbookERD.Core.DBContext;
using LogbookERD.Core.Models;
using System.Data.Entity;

namespace LogbookERD.Core.Repository
{
    public class PerfomerRepository : IRepository<Perfomer>
    {
        private readonly AppDBContext _appDBContext;

        public PerfomerRepository(AppDBContext appDBContext) => _appDBContext = appDBContext;

        public void Add(Perfomer perfomer)
        {
            if (perfomer == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(perfomer));
            }
            if (_appDBContext.Perfomer.Any(e => e.Id == perfomer.Id))
            {
                throw new ArgumentException("These performers of work exist.", nameof(perfomer));
            }

            _appDBContext.Perfomer.Add(perfomer);
            _appDBContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var perfomer = _appDBContext.Perfomer.FirstOrDefault(e => e.Id == id)
                            ?? throw new InvalidOperationException("Item with ID not found");

            _appDBContext.Perfomer?.Remove(perfomer);
            _appDBContext.SaveChanges();
        }

        public void Updata(Perfomer perfomer)
        {
            if (perfomer == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(perfomer));
            }

            var oldItem = _appDBContext.Perfomer.FirstOrDefault(e => e.Id == perfomer.Id)
                            ?? throw new InvalidOperationException("Item with ID not found");

            oldItem.Perfomers = perfomer.Perfomers;
            _appDBContext.SaveChanges();
        }

        public IQueryable<Perfomer> GetQueryableAll()
            => _appDBContext.Perfomer.Include(e => e.Documents).Select(e => e);
    }
}
