using Ardalis.SmartEnum;
using System.Text.Json.Serialization;

namespace LogbookERD.Core.Data.Enum
{
    public class TypeDocumentation : SmartEnum<TypeDocumentation>
    {
        public static TypeDocumentation Unknown = new("Unknown", "", 0);
        public static TypeDocumentation RepairCompletionAct = new("АВР", "Акт о выполненных  работах по ремонту оборудования", 1);
        public static TypeDocumentation RepairCompletionActS4 = new("АВР4", "Акт о выполненных  работах по ремонту оборудования (класс безопасности 4)", 2);
        public static TypeDocumentation RepairActEquipmentList = new("ПО", "Перечень оборудования к акту о выполненных работах по ремонту оборудования", 3);
        public static TypeDocumentation CompletedWorkReport = new("ВВР", "Ведомость выполненных работ", 4);
        public static TypeDocumentation MaterialsUsageReport = new("ВИМ", "Ведомость фактически Затраченных (Используемых) материалов и запасных частей", 5);
        public static TypeDocumentation EquipmentDefectReport = new("АДО", "Акт о дефектах оборудования (трубопроводов)", 6);
        public static TypeDocumentation EquipmentClosureProtocol = new("ПЗО", "Протокол закрытия оборудования", 7);
        public static TypeDocumentation PostRepairInspectionReport = new("ППИ", "Протокол проверки исправности оборудования после ремонта", 8);
        public static TypeDocumentation LeakTestProtocol = new("ПИО", "Протокол испытания оборудования на плотность", 9);
        public static TypeDocumentation OperationalControlReport = new("ПОК", "Протокол операционного контроля при ремонте оборудования", 10);
        public static TypeDocumentation ReplacementMaterialsReport = new("АИМЗ", "Акт об использовании материалов заменителей при ремонте", 11);
        public static TypeDocumentation InstallationCompletionReport = new("АОМ", "Акт окончания монтажа оборудования (трубопровода)", 12);
        public static TypeDocumentation TechnicalConditionAct = new("АТС", "Акт о техническом состоянии оборудования", 13);

        private TypeDocumentation(string name, string abbreviationDecoding, int value)
             : base(name, value) => AbbreviationDecoding = abbreviationDecoding;

        [JsonPropertyName("AbbreviationDecoding")]
        public string AbbreviationDecoding { get; }
    }
}
