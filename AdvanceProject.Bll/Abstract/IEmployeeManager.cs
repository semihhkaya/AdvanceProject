using AdvanceProject.Core.Result;
using AdvanceProject.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Abstract
{
	public interface IEmployeeManager
	{
		Task<IDataResult<EmployeeRegisterDTO>> GetUserByMail(string email);
	}
}
