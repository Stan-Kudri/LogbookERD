namespace LogbookERD.Core.Models
{
    public class ExecutRepairDocumentation : Entity
    {
        public ExecutRepairDocumentation()
        {
        }

        public List<Document> Documents { get; set; }
    }
}
