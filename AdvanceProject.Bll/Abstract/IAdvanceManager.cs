using AdvanceProject.Core.Result;
using AdvanceProject.Dto.Advance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Abstract
{
	public interface IAdvanceManager
	{
		Task<IDataResult<AdvanceInsertDTO>> AddAdvance(AdvanceInsertDTO dto);
	}
}
