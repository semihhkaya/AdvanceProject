using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceProject.API.Contract.Request
{
	public class GetAdvanceApproveEmployeeRequestModel
	{
		public int AdvanceId { get; set; }
		public List<int> Titles { get; set; }
	}
}
