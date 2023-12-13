using AdvanceProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Abstract
{
	public interface IAuthRepository
	{
		Task<Employee> Register(Employee employee, string password);
		Task<Employee> Login(string username, string password);
	}
}
