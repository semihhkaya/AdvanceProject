using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Entities
{
	public partial class EmployeeProject : BaseEntity
	{
		public int EmployeeId { get; set; }
		public int ProjectId { get; set; }

		public virtual Employee Employee { get; set; }
		public virtual Project Project { get; set; }
	}
}
