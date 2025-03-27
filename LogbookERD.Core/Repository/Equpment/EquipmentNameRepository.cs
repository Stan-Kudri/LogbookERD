using LogbookERD.Core.DBContext;
using LogbookERD.Core.Models.ItemRepository.Equipments;
using System.Data.Entity;

namespace LogbookERD.Core.Repository.Equpment
{
    public class EquipmentNameRepository : IRepository<EquipmentName>
    {
        private readonly AppDBContext _appDBContext;

        public EquipmentNameRepository(AppDBContext appDBContext) => _appDBContext = appDBContext;

        public void Add(EquipmentName equipmentName)
        {
            if (equipmentName == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(equipmentName));
            }
            if (_appDBContext.EquipmentNames.Any(e => e.Id == equipmentName.Id))
            {
                throw new ArgumentException("These equipment name of work exist.", nameof(equipmentName));
            }

            _appDBContext.EquipmentNames.Add(equipmentName);
            _appDBContext.SaveChanges();
        }

        public void Remove(Guid id)
        {
            var perfomer = _appDBContext.EquipmentNames.FirstOrDefault(e => e.Id == id)
                            ?? throw new InvalidOperationException("Item with ID not found.");

            _appDBContext.EquipmentNames?.Remove(perfomer);
            _appDBContext.SaveChanges();
        }

        public void Updata(EquipmentName equipmentName)
        {
            if (equipmentName == null)
            {
                throw new ArgumentNullException("Incorrect data.", nameof(equipmentName));
            }

            var oldItem = _appDBContext.EquipmentNames.FirstOrDefault(e => e.Id == equipmentName.Id)
                            ?? throw new InvalidOperationException("Item with ID not found.");

            oldItem.Name = equipmentName.Name;
            _appDBContext.SaveChanges();
        }

        public EquipmentName GetEquipmentName(string name)
            => _appDBContext.EquipmentNames.FirstOrDefault(e => e.Name == name) ?? throw new InvalidOperationException("Name with not fount.");

        public IQueryable<EquipmentName> GetQueryableAll()
            => _appDBContext.EquipmentNames
                    .Include(e => e.EquipmentsKKS)
                    .Select(e => e);
    }
}
