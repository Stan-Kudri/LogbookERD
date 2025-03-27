using LogbookERD.Core.DBContext;
using LogbookERD.Core.Models.ItemRepository.Equipments;
using System.Data.Entity;

namespace LogbookERD.Core.Repository.Equpment
{
    public class EquipmentKKSRepository : IRepository<EquipmentKKS>
    {
        private readonly AppDBContext _appDBContext;

        public EquipmentKKSRepository(AppDBContext appDBContext) => _appDBContext = appDBContext;

        public void Add(EquipmentKKS equipmentKKS)
        {
            if (equipmentKKS == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(equipmentKKS));
            }
            if (_appDBContext.EquipmentNames.Any(e => e.Id == equipmentKKS.Id))
            {
                throw new ArgumentException("These KKS of work exist.", nameof(equipmentKKS));
            }

            _appDBContext.EquipmentKKS.Add(equipmentKKS);
            _appDBContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var equipmentKKS = _appDBContext.EquipmentKKS.FirstOrDefault(e => e.Id == id)
                            ?? throw new InvalidOperationException("Item with ID not found");

            _appDBContext.EquipmentKKS?.Remove(equipmentKKS);
            _appDBContext.SaveChanges();
        }

        public void Updata(EquipmentKKS equipmentKKS)
        {
            if (equipmentKKS == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(equipmentKKS));
            }

            var oldItem = _appDBContext.EquipmentKKS.FirstOrDefault(e => e.Id == equipmentKKS.Id)
                            ?? throw new InvalidOperationException("Item with ID not found");

            oldItem.KKS = equipmentKKS.KKS;
            oldItem.EquipmentNameId = equipmentKKS.EquipmentNameId;
            _appDBContext.SaveChanges();
        }

        public void AddRange(List<EquipmentKKS> equipmentKKS)
        {
            foreach (var item in equipmentKKS)
            {
                _appDBContext.Add(item);
            }
        }

        public IQueryable<EquipmentKKS> GetQueryableAll()
            => _appDBContext.EquipmentKKS.Include(e => e.EquipmentInDocs).Select(e => e);
    }
}
