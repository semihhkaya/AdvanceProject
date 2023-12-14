using AdvanceProject.Core.Result;
using AdvanceProject.Dto.Title;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Abstract
{
	public interface ITitleManager
	{
		Task<IDataResult<List<TitleSelectDTO>>> GetAll();
	}
}
