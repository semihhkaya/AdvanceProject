using AdvanceProject.Core.Entities;
using AdvanceProject.Dal.Abstract;
using AdvanceProject.Dal.Base;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Concrete
{
	public class EmployeeRepository : BaseRepository,IEmployeeRepository
	{
		public EmployeeRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
		{
		}
		public async Task<Employee> GetUserByEmail(string email)
		{
			var sqlquery = "SELECT * FROM Employee WHERE Email = @Email";
			var parameters = new DynamicParameters();
			parameters.Add("@Email", email, DbType.String);

			var user = await Connection.QueryFirstOrDefaultAsync<Employee>(sqlquery, parameters, Transaction);
			return user;
		}
		
	}
}
