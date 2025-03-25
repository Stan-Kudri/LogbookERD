namespace LogbookERD.Core.Models.ItemRepository
{
    public class ExecutRepairDocumentation : Entity
    {
        public ExecutRepairDocumentation()
        {
        }

        public List<Document> Documents { get; set; }
    }
}
