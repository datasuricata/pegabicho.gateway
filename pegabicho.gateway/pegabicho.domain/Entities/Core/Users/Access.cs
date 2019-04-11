using pegabicho.domain.Entities.Base;
using static pegabicho.domain.Entities.Enums;

namespace pegabicho.domain.Entities.Core.Users
{
    public class Access : EntityBase
    {
        public LevelAccess Level { get; set; }
        public ModuleService Module { get; set; }
    } 
}
