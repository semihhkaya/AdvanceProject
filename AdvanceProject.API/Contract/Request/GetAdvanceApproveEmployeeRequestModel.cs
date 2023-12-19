using System.Collections.Generic;

namespace AdvanceProject.API.Contract.Request
{
	public class GetAdvanceApproveEmployeeRequestModel
	{
		public int AdvanceId { get; set; }
		public List<int> Titles { get; set; }
	}
}
