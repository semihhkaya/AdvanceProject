using AdvanceProject.Dto.Advance;
using AdvanceProject.Dto.Employee;
using AdvanceProject.Dto.Status;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dto.AdvanceHistory
{
	public class AdvanceHistorySelectDTO
    {
        public int Id { get; set; }
        public int? StatusId { get; set; }
        public int? AdvanceId { get; set; }
        public int? TransactorId { get; set; }
        public decimal? ApprovedAmount { get; set; }
        public DateTime? Date { get; set; }

        public virtual AdvanceSelectDTO Advance { get; set; }
        public virtual EmployeeSelectDTO Status { get; set; }
        public virtual StatusSelectDTO Transactor { get; set; }
    }
}
