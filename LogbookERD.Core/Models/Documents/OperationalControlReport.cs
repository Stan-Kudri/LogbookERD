using LogbookERD.Core.Data.Enum;
using LogbookERD.Core.Data.Identificator;

namespace LogbookERD.Core.Models.Documents
{
    public class OperationalControlReport : BaseNumberGenerator
    {
        public OperationalControlReport() : base(TypeDocumentation.OperationalControlReport)
        {
        }
    }
}
