﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dto.Advance
{
	public class AdanceHistoryApproveDTO
	{
		public int StatusID { get; set; }
		public int AdvanceID { get; set; }
		public int TransactorID { get; set; }
		public decimal AdvanceAmount { get; set; }
		
	}
}
