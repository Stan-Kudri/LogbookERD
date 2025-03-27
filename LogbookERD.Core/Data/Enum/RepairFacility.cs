using Ardalis.SmartEnum;
using System.Text.Json.Serialization;

namespace LogbookERD.Core.Data.Enum
{
    public class RepairFacility : SmartEnum<RepairFacility>
    {
        public static RepairFacility GC = new("GC", "ОСО", "Общестанционное оборудование", 0);
        public static RepairFacility EBFirst = new("EBFirst", "ЭБ 1", "Энергоблок 1", 1);
        public static RepairFacility EBSecond = new("EBSecond", "ЭБ 2", "Энергоблок 2", 2);

        private RepairFacility(string name, string nameRussion, string abbreviationDecoding, int value)
             : base(name, value)
        {
            AbbreviationDecoding = abbreviationDecoding;
            Facility = nameRussion;
        }

        [JsonPropertyName("AbbreviationDecoding")]
        public string AbbreviationDecoding { get; }

        [JsonPropertyName("FacilityRussianName")]
        public string Facility { get; }
    }
}
