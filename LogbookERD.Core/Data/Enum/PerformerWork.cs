using Ardalis.SmartEnum;
using System.Text.Json.Serialization;

namespace LogbookERD.Core.Data.Enum
{
    public class PerformerWork : SmartEnum<PerformerWork>
    {
        public static PerformerWork CRS = new PerformerWork("CRS", "ЦЦР", "Цех централизованного ремонта", 0, false);
        public static PerformerWork ES = new PerformerWork("ES", "ЭЦ", "Электрический цех", 1, false);
        public static PerformerWork TAMS = new PerformerWork("TAMS", "ЦТАИ", "Цех тепловой автоматики и регулирования", 2, false);
        public static PerformerWork BERN = new PerformerWork("BERN", "БЭРН", "Белэнергоремналадка", 3);
        public static PerformerWork ATE = new PerformerWork("ATE", "АТЭ", "Атомэнергоремонт", 4);
        public static PerformerWork ROS = new PerformerWork("ROS", "РосАС", "Росатом Сервис", 5);
        public static PerformerWork BAS = new PerformerWork("BAS", "БАС", "Белатомсервис", 6);

        private PerformerWork(string name, string nameRussion, string abbreviationDecoding, int value, bool isContractor = true)
             : base(name, value)
        {
            AbbreviationDecoding = abbreviationDecoding;
            Performer = nameRussion;
            IsContractor = isContractor;
        }

        [JsonPropertyName("AbbreviationDecoding")]
        public string AbbreviationDecoding { get; }

        [JsonPropertyName("PerformerRussianName")]
        public string Performer { get; }

        [JsonPropertyName("IsContractor")]
        public bool IsContractor { get; }
    }
}
