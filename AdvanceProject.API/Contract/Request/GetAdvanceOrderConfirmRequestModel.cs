using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceProject.API.Contract.Request
{
	public class GetAdvanceOrderConfirmRequestModel
	{
		public int BusinessUnitId { get; set; }
		public List<int> Titles { get; set; }
	}
}
