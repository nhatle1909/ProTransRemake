using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Distance : BaseEntity
    {
        //Field
        public required decimal Value {  get; set; }
        //Foreignkey
        public required Guid RootAgencyId { get; set; }
        public required Guid TargetAgencyId { get; set; }
        //Relationship
        public required Agency RootAgency { get; set; }
        public required Agency TargetAgency { get; set; }
    }
}
