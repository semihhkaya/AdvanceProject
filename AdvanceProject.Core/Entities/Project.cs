using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Entities
{
	public partial class Project : BaseEntity
    {
        public Project()
        {
            Advances = new HashSet<Advance>();
            EmployeeProjects = new HashSet<EmployeeProject>();
        }

        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? StartingDate { get; set; }

        public virtual ICollection<Advance> Advances { get; set; }
        public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; }
    }
}
