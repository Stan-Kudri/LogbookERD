using LogbookERD.Core.Data.Enum;
using LogbookERD.Core.Data.Identificator;

namespace LogbookERD.Core.Models.Documents
{
    public class LeakTestProtocol : BaseNumberGenerator
    {
        public LeakTestProtocol() : base(TypeDocumentation.LeakTestProtocol)
        {
        }
    }
}
