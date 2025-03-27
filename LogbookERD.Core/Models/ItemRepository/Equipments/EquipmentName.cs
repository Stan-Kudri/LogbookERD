namespace LogbookERD.Core.Models.ItemRepository.Equipments
{
    public class EquipmentName : Entity
    {
        public EquipmentName()
        {
        }

        //Наименовани оборудование (Тип, марка и т.д.)
        public required string Name { get; set; }

        //Список оборудования
        public List<EquipmentKKS>? EquipmentsKKS { get; set; } = null;
    }
}
