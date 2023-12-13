using AdvanceProject.Core.Result;
using AdvanceProject.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Abstract
{
	public interface IAuthManager
	{
		Task<IDataResult<EmployeeRegisterDTO>> Register(EmployeeRegisterDTO dto,string password);
		Task<IDataResult<EmployeeSelectDTO>> Login(EmployeeLoginDTO dto);
		
	}
}
