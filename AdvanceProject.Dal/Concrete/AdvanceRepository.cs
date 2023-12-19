using AdvanceProject.Core.Entities;
using AdvanceProject.Dal.Abstract;
using AdvanceProject.Dal.Base;
using AdvanceProject.Dto.Advance;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
			parameters.Add("@StatusID", 201, DbType.Int32);
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

			var results = Connection.Query<EmployeeAdvanceResponseDto>(sql, parameter);
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

		public List<AdvanceConfirmDTO> GetAdvanceConfirmEmployee(int employeeId)
		{
			var sql = @"select ah.AdvanceID,ee.Name 'EmployeeName' ,ee.Surname 'EmployeeSurname',bu.BusinessUnitName 'EmployeeBusinessUnit',t.TitleName 'EmployeeTitle',a.AdvanceDescription,ah.StatusID,a.AdvanceAmount,a.RequestDate,a.DesiredDate, e.Name'TransactorName',e.Surname'TransactorSurname',t2.TitleName 'TransactorTitleName',s.StatusName 'LastStatusName',ah.ApprovedAmount,uppere.Name 'NextTransactorEmployeeName',uppere.Surname 'NextTransactorEmployeeSurname',t3.TitleName 'NextTransactorEmployeeTitle',t3.ID 'NextTransactorEmployeeTitleID' from AdvanceHistory ah
			  JOIN Employee e on e.ID = ah.TransactorID 
			  JOIN Employee uppere on uppere.ID = e.UpperEmployeeID 
			  join Advance a on a.ID=ah.AdvanceID
			  join Employee ee on ee.ID=a.EmployeeID 
              join Status s on s.ID = ah.StatusID
			  join BusinessUnit bu on bu.ID = ee.BusinessUnitID
              join Title t on t.ID = ee.TitleID
			  join Title t2 on t2.ID = e.TitleID
			  join Status sa on sa.ID = a.StatusID
			  join Title t3 on t3.ID = uppere.TitleID
			  where uppere.ID = @EmployeeId";

			var parameter = new DynamicParameters();
			parameter.Add("@EmployeeId", employeeId, DbType.Int32);

			var results = Connection.Query<AdvanceConfirmDTO>(sql, parameter);
			List<AdvanceConfirmDTO> data = results.ToList();

			return data;
		}

		//  -- 5000 TL'lik gelen avans tutarını hangi TitleId'ler onaylayacak? avans tutarı ile birlikte rule gittim hangi rule id'lerin bu miktarı onaylayacağını buldum 
		// Example Output : TitleId[4, 3]
		public List<int> GetTitleID(decimal advanceAmount)
		{
			var sql = @"SELECT TitleID FROM [Rule] WHERE MinAmount <= @AdvanceAmount ORDER BY MaxAmount";

			var parameter = new DynamicParameters();
			parameter.Add("@AdvanceAmount", advanceAmount, DbType.Int32);

			var results = Connection.Query<int>(sql, parameter);

			return results.ToList();

		}
		//Bu avansı sırası ile kimler onaylayacak?
		public List<AdvanceOrderConfirmDTO> GetAdvanceOrderConfirm(int businessUnitId, List<int> titles)
		{
			var sql = @"
			SELECT e.ID AS EmployeeID, e.Name AS EmployeeName, e.Surname AS EmployeeSurname, e.TitleID, t.TitleName
			FROM Employee e
			JOIN Title t ON e.TitleID = t.ID
			WHERE e.TitleID IN @TitleIDs AND e.BusinessUnitID = @BusinessUnitID
			ORDER BY t.ID";

			var parameters = new
			{
				TitleIDs = titles,
				BusinessUnitID = businessUnitId
			};


			var results = Connection.Query<AdvanceOrderConfirmDTO>(sql, parameters);

			return results.ToList();
		}

		//  -- Bir avansı hangi kişilerin onayladığını gösterir 
		public List<AdvanceApprovedEmployeeDTO> GetAdvanceApproveEmployee(int advanceID, List<int> titles)
		{
			var sql = @"
                SELECT s.ID as StatusId, s.StatusName, e.Name as ApprovedEmployeeName, e.TitleID as TitleId, e.BusinessUnitID, a.AdvanceID,a.TransactorID
                FROM Status s  
                JOIN AdvanceHistory a ON s.ID = a.StatusID
                JOIN Employee e ON e.ID = a.TransactorID
                WHERE AdvanceID = @AdvanceID
                AND e.TitleID IN @TitleIDs";

			var parameters = new
			{
				TitleIDs = titles,
				AdvanceID = advanceID
			};


			var results = Connection.Query<AdvanceApprovedEmployeeDTO>(sql, parameters);

			return results.ToList();
		}

		public async Task<AdanceHistoryApproveDTO> AddAdvanceHistoryApprove(AdanceHistoryApproveDTO dto)
		{
			var sql = @"Insert into AdvanceHistory (StatusID,AdvanceID,TransactorID,ApprovedAmount,Date) VALUES (@StatusID,@AdvanceID,@TransactorID,@ApprovedAmount,@Date)";

			var parameters = new DynamicParameters();
			parameters.Add("@StatusID", dto.StatusID, DbType.Int32);
			parameters.Add("@AdvanceID", dto.AdvanceID, DbType.Int32);
			parameters.Add("@TransactorID", dto.TransactorID, DbType.Int32);
			parameters.Add("@ApprovedAmount", dto.AdvanceAmount, DbType.Decimal);
			parameters.Add("@Date", DateTime.Now, DbType.DateTime);

			int rowsAffected = await Connection.ExecuteAsync(sql, parameters);

			return dto;
		}


		public async Task<bool> GetAdvanceChangeStatus(int advanceId, int nowStatus)
		{
			var sql = @"Update Advance Set StatusID = @StatusID Where ID = @AdvanceID";

			var parameters = new DynamicParameters();
			parameters.Add("@StatusID", nowStatus, DbType.Int32);
			parameters.Add("@AdvanceID", advanceId, DbType.Int32);

			int rowsAffected = await Connection.ExecuteAsync(sql, parameters);
			if (rowsAffected > 0)
			{
				return true;
			}

			return false;
		}

		public async Task<List<UserAdvanceListDTO>> GetUserAdvanceList(int employeeId, int businessUnitID)
		{
			var sql = @"SELECT a.ID as AdvanceID, e.Name, e.Surname, t.TitleName, a.StatusID as AdvanceStatusID, s.StatusName, a.RequestDate, a.DesiredDate, a.AdvanceAmount
							FROM Advance a JOIN Employee e ON e.ID = a.EmployeeID
							JOIN Title t ON t.ID = e.TitleID
							JOIN Status s ON s.ID = a.StatusID
							WHERE a.StatusID = (
								SELECT (s.ID-1)
								FROM Employee e 
								JOIN Title t ON e.TitleID = t.ID 
								JOIN Status s ON s.TitleID = t.ID
								WHERE e.ID = @EmployeeID AND e.BusinessUnitID = @BusinnesUnitID
												)";

			var parameters = new DynamicParameters();
			parameters.Add("@BusinnesUnitID", businessUnitID, DbType.Int32);
			parameters.Add("@EmployeeID", employeeId, DbType.Int32);


			var data = await Connection.QueryAsync<UserAdvanceListDTO>(sql, parameters);

			if (data != null)
			{
				return data.ToList();
			}

			return new List<UserAdvanceListDTO>();
		}
	}
}
