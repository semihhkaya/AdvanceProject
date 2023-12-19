using AdvanceProject.Core.Result;
using AdvanceProject.Dto.BusinessUnit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Abstract
{
	public interface IBusinessUnitManager
	{
		Task<IDataResult<List<BusinessUnitSelectDTO>>> GetAll();
	}
}
