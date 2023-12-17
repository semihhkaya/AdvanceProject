using AdvanceProject.Core.Entities;
using AdvanceProject.Dal.Abstract;
using AdvanceProject.Dal.Base;
using AdvanceProject.Dto.Advance;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Concrete
{
	public class AdvanceRepository : BaseRepository, IAdvanceRepository
	{
		public AdvanceRepository(IDbConnection connection, IDbTransaction transaction) : base(connection, transaction)
		{
		}

		public async Task<Advance> AddAdvance(Advance advance)
		{
			string query = @"INSERT INTO Advance(AdvanceAmount, AdvanceDescription, ProjectID, DesiredDate, RequestDate, StatusID, EmployeeID) 
                 VALUES (@AdvanceAmount, @AdvanceDescription, @ProjectID, @DesiredDate, @RequestDate, @StatusID, @EmployeeID);
                 SELECT SCOPE_IDENTITY();";

			var parameters = new DynamicParameters();
			parameters.Add("@AdvanceAmount", advance.AdvanceAmount, DbType.Decimal);
			parameters.Add("@AdvanceDescription", advance.AdvanceDescription, DbType.String);
			parameters.Add("@ProjectID", advance.ProjectId, DbType.Int32);
			parameters.Add("@DesiredDate", advance.DesiredDate, DbType.DateTime); //Şirketin ödicem dediği tarih
			parameters.Add("@RequestDate", DateTime.Now, DbType.DateTime); //İstenen tarih şu an
			parameters.Add("@StatusID", 101, DbType.Int32);
			parameters.Add("@EmployeeID", advance.EmployeeId, DbType.Int32);

			int AdvanceId = await Connection.ExecuteScalarAsync<int>(query, parameters, Transaction);
			//Advance history ekleme bll'de transaction başlatılacak
			string queryHistory = @"INSERT INTO AdvanceHistory(StatusID, AdvanceID, TransactorID, ApprovedAmount, Date) 
                       VALUES (@StatusID, @AdvanceID, @TransactorID, @ApprovedAmount, @Date)";

			var dynamicParametersHistory = new DynamicParameters();
			dynamicParametersHistory.Add("@StatusID", 201, DbType.Int32);
			dynamicParametersHistory.Add("@AdvanceID", AdvanceId, DbType.Int32);
			dynamicParametersHistory.Add("@TransactorID", advance.EmployeeId, DbType.Int32);
			dynamicParametersHistory.Add("@ApprovedAmount", 0, DbType.Decimal);
			dynamicParametersHistory.Add("@Date", DateTime.Now, DbType.DateTime);

			int rowsAffected = await Connection.ExecuteAsync(queryHistory, dynamicParametersHistory, Transaction);

			return advance;

		}
	

		public List<EmployeeAdvanceResponseDto> GetAdvanceListData(int employeeId)
		{
			var sql = @"SELECT a.ID as 'AdvanceID', a.AdvanceAmount, a.AdvanceDescription, a.DesiredDate, a.RequestDate, a.ProjectID, p.ProjectName,	a.StatusID, s.StatusName, a.EmployeeID, e.Name as 'EmployeeName', e.Surname
						FROM Advance a join Project p on p.ID = a.ProjectID
						JOIN Status s on s.ID = a.StatusID
						JOIN Employee e on e.ID = a.EmployeeID Where a.EmployeeID = @EmployeeId";

			var parameter = new DynamicParameters();
			parameter.Add("@EmployeeId", employeeId, DbType.Int32);

			var results = Connection.Query<EmployeeAdvanceResponseDto>(sql,parameter);
			List<EmployeeAdvanceResponseDto> data = results.ToList();

			return data;
		}

		public List<AdvanceDetailDTO> GetAdvanceDetails(int advanceId)
		{
			var sql = @"Select ah.AdvanceID, a.AdvanceAmount, a.AdvanceDescription,s.ID 'StatusID',s.StatusName,e.Name AS 'EmployeeName',e.Surname,ah.TransactorID, ah.ApprovedAmount,ah.Date ,em.Name 'UpperEmployeeName',em.ID 'UpperEmployeeId',p.DeterminedPaymentDate,r.ReceiptNo from AdvanceHistory ah LEFT join Advance a on a.ID = ah.AdvanceID LEFT join Status s on s.ID = ah.StatusID LEFT join Employee e on e.ID = ah.TransactorID LEFT join Payment p on p.AdvanceID = ah.AdvanceID LEFT join Receipt r on r.AdvanceID = ah.AdvanceID LEFT join Employee em on em.ID = e.UpperEmployeeID Where ah.AdvanceID = @AdvanceID";

			var parameter = new DynamicParameters();
			parameter.Add("@AdvanceID", advanceId, DbType.Int32);

			var results = Connection.Query<AdvanceDetailDTO>(sql, parameter);
			List<AdvanceDetailDTO> data = results.ToList();

			return data;
		}

	}
}
