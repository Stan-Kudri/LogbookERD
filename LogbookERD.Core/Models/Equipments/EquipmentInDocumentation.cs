namespace LogbookERD.Core.Models.Equipments
{
    public class EquipmentInDocumentation : Entity
    {
        public EquipmentInDocumentation()
        {
        }

        //Идентификатор принадлежности к ИРД
        public Guid ExecutRepairDocId { get; set; }

        //ИРД к которому принадлежит документ
        public ExecutRepairDocumentation ExecutRepairDocumentation { get; set; }

        //Списпок KKS к документу
        public List<EquipmentKKS> KKS { get; set; }

        //Документ к которому пренадлежит оборудование
        public List<Document> Document { get; set; }
    }
}
