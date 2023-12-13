using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Entities
{
	public partial class Payment : BaseEntity
    {
        public Payment()
        {
            Advances = new HashSet<Advance>();
        }

        public int Id { get; set; }
        public DateTime? DeterminedPaymentDate { get; set; }
        public int? FinanceManagerId { get; set; }

        public virtual Employee FinanceManager { get; set; }
        public virtual ICollection<Advance> Advances { get; set; }
    }
}
