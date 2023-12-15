using AdvanceProject.Dto.Advance;
using AdvanceProject.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dto.Payment
{
	public class PaymentSelectDTO
	{
		public int Id { get; set; }
		public DateTime? DeterminedPaymentDate { get; set; }
		public int? FinanceManagerId { get; set; }
		public int? AdvanceId { get; set; }

		public virtual EmployeeSelectDTO Employee { get; set; }
		public virtual ICollection<EmployeeSelectDTO> Employees { get; set; }

		public virtual AdvanceSelectDTO Advance { get; set; }
		public virtual ICollection<AdvanceSelectDTO> Advances { get; set; }


	}
}
