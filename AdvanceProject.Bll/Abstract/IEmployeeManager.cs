using AdvanceProject.Core.Result;
using AdvanceProject.Dto.Employee;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Abstract
{
	public interface IEmployeeManager
	{
		Task<IDataResult<EmployeeRegisterDTO>> GetUserByMail(string email);
		Task<IDataResult<List<EmployeeSelectDTO>>> GetAll();
	}
}
