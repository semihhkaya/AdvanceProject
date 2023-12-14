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
	public class BusinessUnitRepository:BaseRepository,IBusinessUnitRepository
	{
		public BusinessUnitRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
		{
		}

		public async Task<List<BusinessUnit>> GetAll()
		{
			var sqlQuery = "SELECT * FROM BusinessUnit";

			var parameters = new DynamicParameters();
			var data = await Connection.QueryAsync<BusinessUnit>(sqlQuery, parameters, Transaction);
			return data.ToList();
		}
	}
}
