using AdvanceProject.Dto.AdvanceHistory;
using AdvanceProject.Dto.Employee;
using AdvanceProject.Dto.Payment;
using AdvanceProject.Dto.Project;
using AdvanceProject.Dto.Receipt;
using AdvanceProject.Dto.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dto.Advance
{
	public class AdvanceSelectDTO
	{
        public int Id { get; set; }
        public decimal? AdvanceAmount { get; set; }
        public string AdvanceDescription { get; set; }
        public int? ProjectId { get; set; }
        public DateTime? DesiredDate { get; set; }
        public int? StatusId { get; set; }
        public int? EmployeeId { get; set; }
        public DateTime? RequestDate { get; set; }

        public virtual EmployeeSelectDTO Employees { get; set; }
        public virtual StatusSelectDTO Statuses { get; set; }
        public virtual ProjectSelectDTO Projects { get; set; }

        public virtual ICollection<AdvanceHistorySelectDTO> AdvanceHistories { get; set; }
        public virtual ICollection<ReceiptSelectDTO> Receipts { get; set; }
        public virtual ICollection<PaymentSelectDTO> Payments { get; set; }
    }
}
