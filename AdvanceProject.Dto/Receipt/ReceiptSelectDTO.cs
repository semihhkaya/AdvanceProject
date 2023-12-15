using AdvanceProject.Dto.Advance;
using AdvanceProject.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dto.Receipt
{
	public class ReceiptSelectDTO
    {
        public int Id { get; set; }
        public string ReceiptNo { get; set; }
        public bool? IsRefundReceipt { get; set; }
        public int? AdvanceId { get; set; }
        public DateTime? Date { get; set; }
        public int? AccountantId { get; set; }

        public virtual EmployeeSelectDTO Employees { get; set; }
        public virtual AdvanceSelectDTO Advances { get; set; }

    }
}
