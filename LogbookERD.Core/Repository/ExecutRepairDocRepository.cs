using LogbookERD.Core.DBContext;
using LogbookERD.Core.Models;

namespace LogbookERD.Core.Repository
{
    public class ExecutRepairDocRepository
    {
        private readonly AppDBContext _appDBContext;

        public ExecutRepairDocRepository(AppDBContext appDBContext) => _appDBContext = appDBContext;

        public void Add(ExecutRepairDocumentation erd)
        {
            if (erd == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(erd));
            }
            if (_appDBContext.ExecutRepairDocumentations.Any(e => e.Id == erd.Id))
            {
                throw new ArgumentException("These ERD of work exist.", nameof(erd));
            }

            _appDBContext.ExecutRepairDocumentations.Add(erd);
            _appDBContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var erd = _appDBContext.ExecutRepairDocumentations.FirstOrDefault(e => e.Id == id)
                            ?? throw new InvalidOperationException("Item with ID not found");

            _appDBContext.ExecutRepairDocumentations?.Remove(erd);
            _appDBContext.SaveChanges();
        }

        //No implementation
        public void Updata(ExecutRepairDocumentation erd)
        {
            if (erd == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(erd));
            }

            var oldItem = _appDBContext.ExecutRepairDocumentations.FirstOrDefault(e => e.Id == erd.Id)
                            ?? throw new InvalidOperationException("Item with ID not found");

            _appDBContext.SaveChanges();
        }

        public IQueryable<ExecutRepairDocumentation> GetQueryableAll()
            => _appDBContext.ExecutRepairDocumentations;
    }
}
