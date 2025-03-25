using System.ComponentModel.DataAnnotations;

namespace LogbookERD.Core.Models.ItemRepository.Equipments
{
    public class EquipmentKKS : Entity
    {
        public EquipmentKKS()
        {
        }

        //Оборудование
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Only Latin letters and numbers are allowed.")]
        public required string KKS { get; set; }

        //Идентификатор наименования оборудования
        public Guid EquipmentNameId { get; set; }

        public EquipmentName EquipmentName { get; set; }

        //Оборудование входящее в документ
        public List<EquipmentInDocumentation> EquipmentInDocs { get; set; }
    }
}
