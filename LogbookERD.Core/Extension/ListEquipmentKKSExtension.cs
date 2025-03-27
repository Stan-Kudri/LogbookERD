using LogbookERD.Core.Models;
using LogbookERD.Core.Models.ItemRepository.Equipments;

namespace LogbookERD.Core.Extension
{
    public static class ListEquipmentKKSExtension
    {
        public static List<EquipmentKKS> GetListEquipmentKKS(this EquipmentModel equipmentModel, Guid equipmentNameId)
        {
            var listEquipmentKKS = new List<EquipmentKKS>();
            foreach (var item in equipmentModel.KKS)
            {
                var equipmentKKS = new EquipmentKKS() { KKS = item, EquipmentNameId = equipmentNameId };
                listEquipmentKKS.Add(equipmentKKS);
            }

            return listEquipmentKKS;
        }
    }
}
