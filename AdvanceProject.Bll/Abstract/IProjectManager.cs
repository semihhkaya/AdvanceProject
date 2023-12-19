using AdvanceProject.Core.Result;
using AdvanceProject.Dto.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Abstract
{
	public interface IProjectManager
	{
		Task<IDataResult<List<ProjectSelectDTO>>> GetAll();
	}
}
