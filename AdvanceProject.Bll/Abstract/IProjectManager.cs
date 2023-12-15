using AdvanceProject.Core.Result;
using AdvanceProject.Dto.Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Abstract
{
	public interface IProjectManager
	{
		Task<IDataResult<List<ProjectSelectDTO>>> GetAll();
	}
}
