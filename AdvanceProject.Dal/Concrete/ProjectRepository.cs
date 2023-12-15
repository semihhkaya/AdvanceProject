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
	public class ProjectRepository : BaseRepository, IProjectRepository
	{
		public ProjectRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
		{
		}
		public async Task<List<Project>> GetAll()
		{
			var sqlquery = "Select * from Project";

			var parameters = new DynamicParameters();
			var data = await Connection.QueryAsync<Project>(sqlquery, parameters, Transaction);
			return data.ToList();
		}
	}
}
