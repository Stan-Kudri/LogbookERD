using LogbookERD.Core.DBContext;
using LogbookERD.Core.Extension;
using LogbookERD.Core.Models;
using LogbookERD.Core.Models.ItemRepository;
using LogbookERD.Core.Models.ItemRepository.Equipments;
using LogbookERD.Core.Repository.Equpment;

namespace LogbookERD.Core.Service
{
    public class EquipmentService
    {
        private readonly AppDBContext _appDBContext;

        private readonly EquipmentKKSRepository _equipmentKKSRepository;
        private readonly EquipmentNameRepository _equipmentNameRepository;
        private readonly EquipmentInDocRepository _equipmentInDocRepository;

        private ExecutRepairDocumentation _executRepairDocumentation;

        public EquipmentService(EquipmentKKSRepository equipmentKKSRepository,
                               EquipmentNameRepository equipmentNameRepository,
                               EquipmentInDocRepository equipmentInDocRepository,
                               AppDBContext appDBContext)
        {
            _equipmentKKSRepository = equipmentKKSRepository;
            _equipmentNameRepository = equipmentNameRepository;
            _equipmentInDocRepository = equipmentInDocRepository;
            _appDBContext = appDBContext;
        }

        public void InstallationERD(ExecutRepairDocumentation ERD) => _executRepairDocumentation = ERD;

        public void Add(EquipmentModel equipment)
        {
            _equipmentNameRepository.Add(equipment.EquipmentName);
            var equipmentName = _equipmentNameRepository.GetEquipmentName(equipment.EquipmentName.Name);

            var listEquipmentKKS = equipment.GetListEquipmentKKS(equipmentName.Id);
            _equipmentKKSRepository.AddRange(listEquipmentKKS);

            var equipmentInDoc = new EquipmentInDocumentation() { ExecutRepairDocId = _executRepairDocumentation.Id, KKS = listEquipmentKKS };
            _equipmentInDocRepository.Add(equipmentInDoc);
        }
    }
}
