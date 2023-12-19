using System.Collections.Generic;

namespace AdvanceProject.API.Contract.Request
{
	public class GetAdvanceOrderConfirmRequestModel
	{
		public int BusinessUnitId { get; set; }
		public List<int> Titles { get; set; }
	}
}
