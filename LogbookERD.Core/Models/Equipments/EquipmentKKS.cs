namespace LogbookERD.Core.Models.Equipments
{
    public class EquipmentKKS : Entity
    {
        public EquipmentKKS()
        {
        }

        //Оборудование
        public required string KKS { get; set; }

        //Идентификатор наименования оборудования
        public Guid EquipmentNameId { get; set; }

        public EquipmentName EquipmentName { get; set; }

        //Оборудование входящее в документ
        public List<EquipmentInDocumentation> EquipmentInDocs { get; set; }
    }
}
