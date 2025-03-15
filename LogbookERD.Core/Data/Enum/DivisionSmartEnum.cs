using Ardalis.SmartEnum;
using System.Text.Json.Serialization;

namespace LogbookERD.Core.Data.Enum
{
    public class DivisionSmartEnum : SmartEnum<DivisionSmartEnum>
    {
        public static DivisionSmartEnum OPPR = new("OPPR", "ОППР", "Отдел подготовки и проведения ремонтов", 38);
        public static DivisionSmartEnum TS = new("TS", "ТЦ", "Турбинный цех", 22);
        public static DivisionSmartEnum RS = new("RS", "РЦ", "Реакторный цех", 21);
        public static DivisionSmartEnum VACW = new("VACW", "ЦВиК", "Цех вентиляции и кондиционирования", 25);
        public static DivisionSmartEnum СS = new("CS", "ХЦ", "Химический цех", 24);
        //public static DivisionSmartEnum СS = new DivisionSmartEnum("CS", "ЦОРО", "Цех о", 30);
        public static DivisionSmartEnum CRS = new("ES", "ЦЦР", "Цех централизованного ремонта", 35);
        //public static DivisionSmartEnum СS = new DivisionSmartEnum("CS", "ЛПДТК", "Лаборатория", 26);
        public static DivisionSmartEnum ES = new("CS", "ЭЦ", "Электрический цех", 27);
        public static DivisionSmartEnum RSS = new("CS", "ЦРБ", "Цех радиационной безопасности", 33);
        public static DivisionSmartEnum NSD = new("CS", "ОЯБ", "Отдел ядерной безопасности", 31);
        public static DivisionSmartEnum DS = new("CS", "ЦД", "Цех дезактивации", 36);
        public static DivisionSmartEnum MD = new("CS", "ОУРМ", "Отдел модификаций", 54);
        public static DivisionSmartEnum SSS = new("CS", "ЦОС", "Цех обеспечивающих систем", 23);
        public static DivisionSmartEnum ATS = new("CS", "АЦ", "Автотранспортный цех", 11);

        private DivisionSmartEnum(string name, string nameRussion, string abbreviationDecoding, int value)
             : base(name, value)
        {
            AbbreviationDecoding = abbreviationDecoding;
            Division = nameRussion;
        }

        [JsonPropertyName("AbbreviationDecoding")]
        public string AbbreviationDecoding { get; }

        [JsonPropertyName("DivisionRussianName")]
        public string Division { get; }
    }
}
