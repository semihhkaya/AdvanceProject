using System;
using System.Collections.Generic;

namespace AdvanceProject.Core.Entities
{
	public partial class Advance : BaseEntity
	{
		public Advance()
		{
			AdvanceHistories = new HashSet<AdvanceHistory>();
			Receipts = new HashSet<Receipt>();
		}

		public int ID { get; set; }
		public decimal? AdvanceAmount { get; set; }
		public string AdvanceDescription { get; set; }
		public int ProjectId { get; set; }
		public DateTime? DesiredDate { get; set; }
		public int StatusId { get; set; }

		public int EmployeeId { get; set; }
		public DateTime? RequestDate { get; set; }
		public virtual Employee Employee { get; set; }
		public virtual Project Project { get; set; }
		public virtual Status Status { get; set; }
		public virtual ICollection<AdvanceHistory> AdvanceHistories { get; set; }
		public virtual ICollection<Receipt> Receipts { get; set; }
	}
}
