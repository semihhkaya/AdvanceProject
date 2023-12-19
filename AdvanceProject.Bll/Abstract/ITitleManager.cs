using AdvanceProject.Core.Result;
using AdvanceProject.Dto.Title;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Abstract
{
	public interface ITitleManager
	{
		Task<IDataResult<List<TitleSelectDTO>>> GetAll();
	}
}
