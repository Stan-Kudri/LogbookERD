using Ardalis.SmartEnum;
using System.Text.Json.Serialization;

namespace LogbookERD.Core.Data.Enum
{
    public class DivisionSmartEnum : SmartEnum<DivisionSmartEnum>
    {
        public static DivisionSmartEnum OPPR = new DivisionSmartEnum("OPPR", "ОППР", "Отдел подготовки и проведения ремонтов", 38);
        public static DivisionSmartEnum TS = new DivisionSmartEnum("TS", "ТЦ", "Турбинный цех", 22);
        public static DivisionSmartEnum RS = new DivisionSmartEnum("RS", "РЦ", "Реакторный цех", 21);
        public static DivisionSmartEnum VACW = new DivisionSmartEnum("VACW", "ЦВиК", "Цех вентиляции и кондиционирования", 24);
        public static DivisionSmartEnum СS = new DivisionSmartEnum("CS", "ХЦ", "Химический цех", 26);

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
