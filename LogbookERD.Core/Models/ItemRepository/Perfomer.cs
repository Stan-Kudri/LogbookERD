using LogbookERD.Core.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace LogbookERD.Core.Models.ItemRepository
{
    public class Perfomer : Entity
    {
        public Perfomer()
        {
        }

        public Perfomer(List<PerformerWork> performers)
            => Perfomers = performers;

        //Исполнители работ
        public List<string> PerfomersWorks { get; private set; }

        [NotMapped]
        public List<PerformerWork> Perfomers
        {
            get => PerfomersWorks?.Select(e => PerformerWork.FromValue(int.Parse(e))).ToList();
            set => PerfomersWorks = value?.Select(e => e.Value.ToString()).ToList();
        }

        //Наименование документа
        public List<Document> Documents { get; set; }
    }
}
