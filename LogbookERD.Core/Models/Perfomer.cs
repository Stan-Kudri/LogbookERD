using LogbookERD.Core.Data.Enum;

namespace LogbookERD.Core.Models
{
    public class Perfomer : Entity
    {
        public Perfomer()
        {
        }

        //Исполнители работ
        public List<PerformerWork> Perfomers { get; set; }

        //Наименование документа
        public List<Document> Documents { get; set; }
    }
}
