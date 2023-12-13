using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Entities
{
	public partial class Status : BaseEntity
    {
        public Status()
        {
            AdvanceHistories = new HashSet<AdvanceHistory>();
        }

        public int Id { get; set; }
        public string StatusName { get; set; }

        public virtual ICollection<AdvanceHistory> AdvanceHistories { get; set; }
    }
}
