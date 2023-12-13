using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Entities
{
	public partial class BusinessUnit : BaseEntity
    {
        public BusinessUnit()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public string BusinessUnitName { get; set; }
        public string BusinessUnitDescription { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
    }
}
