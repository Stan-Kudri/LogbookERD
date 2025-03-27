using LogbookERD.Core.DBContext;
using LogbookERD.Core.Models.ItemRepository.Equipments;
using System.Data.Entity;

namespace LogbookERD.Core.Repository.Equpment
{
    public class EquipmentInDocRepository : IRepository<EquipmentInDocumentation>
    {
        private readonly AppDBContext _appDBContext;

        public EquipmentInDocRepository(AppDBContext appDBContext) => _appDBContext = appDBContext;

        public void Add(EquipmentInDocumentation equipment)
        {
            if (equipment == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(equipment));
            }
            if (_appDBContext.EquipmentInDocumentations.Any(e => e.Id == equipment.Id))
            {
                throw new ArgumentException("These equipments of work exist.", nameof(equipment));
            }

            _appDBContext.EquipmentInDocumentations.Add(equipment);
            _appDBContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var equipment = _appDBContext.EquipmentInDocumentations.FirstOrDefault(e => e.Id == id)
                            ?? throw new InvalidOperationException("Item with ID not found.");

            _appDBContext.EquipmentInDocumentations?.Remove(equipment);
            _appDBContext.SaveChanges();
        }

        public void Updata(EquipmentInDocumentation equipment)
        {
            if (equipment == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(equipment));
            }

            var oldItem = _appDBContext.EquipmentInDocumentations.FirstOrDefault(e => e.Id == equipment.Id)
                            ?? throw new InvalidOperationException("Item with ID not found.");

            oldItem.ExecutRepairDocId = equipment.ExecutRepairDocId;
            _appDBContext.SaveChanges();
        }

        public IQueryable<EquipmentInDocumentation> GetQueryableAll()
            => _appDBContext.EquipmentInDocumentations
                    .Include(e => e.KKS)
                    .Include(e => e.Document)
                    .Select(e => e);
    }
}
