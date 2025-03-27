using LogbookERD.Core.DBContext;
using LogbookERD.Core.Models.ItemRepository;
using System.Data.Entity;

namespace LogbookERD.Core.Repository
{
    public class DocumentRepository : IRepository<Document>
    {
        private readonly AppDBContext _appDBContext;

        public DocumentRepository(AppDBContext appDBContext) => _appDBContext = appDBContext;

        public void Add(Document document)
        {
            if (document == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(document));
            }
            if (_appDBContext.EquipmentNames.Any(e => e.Id == document.Id))
            {
                throw new ArgumentException("These document of work exist.", nameof(document));
            }

            _appDBContext.Documents.Add(document);
            _appDBContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var document = _appDBContext.Documents.FirstOrDefault(e => e.Id == id)
                            ?? throw new InvalidOperationException("Item with ID not found.");

            _appDBContext.Documents?.Remove(document);
            _appDBContext.SaveChanges();
        }

        public void Updata(Document document)
        {
            if (document == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(document));
            }

            var oldItem = _appDBContext.Documents.FirstOrDefault(e => e.Id == document.Id)
                            ?? throw new InvalidOperationException("Item with ID not found.");

            oldItem.DateRegistration = document.DateRegistration;
            oldItem.Division = document.Division;
            oldItem.RepairComplitionDate = document.RepairComplitionDate;
            oldItem.RepairFacility = document.RepairFacility;
            oldItem.ChangeYearRepair = document.ChangeYearRepair;
            oldItem.EquipmentInDocId = document.EquipmentInDocId;
            oldItem.ExecutRepairDocId = document.ExecutRepairDocId;
            oldItem.OrdinalNumber = document.OrdinalNumber;
            oldItem.RegisterNumber = document.RegisterNumber;
            oldItem.Note = document.Note;
            _appDBContext.SaveChanges();
        }

        public IQueryable<Document> GetQueryableAll()
            => _appDBContext.Documents
                .Include(e => e.Perfomer)
                .Include(e => e.Equipment)
                .Include(e => e.ERD)
                .Select(e => e);
    }
}
