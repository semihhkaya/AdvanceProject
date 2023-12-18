using AdvanceProject.Core.Result;
using AdvanceProject.Dto.Advance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProject.Dal.Concrete.AdvanceRepository;

namespace AdvanceProject.Bll.Abstract
{
	public interface IAdvanceManager
	{
		Task<IDataResult<AdvanceInsertDTO>> AddAdvance(AdvanceInsertDTO dto);
		
		IDataResult<List<EmployeeAdvanceResponseDto>> GetAdvanceListData(int employeeId);
		IDataResult<List<AdvanceDetailDTO>> GetAdvanceDetails(int advanceId);

		Task<IDataResult<List<AdvanceConfirmDTO>>> GetAdvanceConfirmEmployee(int employeeId);
		IDataResult<List<int>> GetTitleID(decimal advanceAmount);

		IDataResult<List<AdvanceOrderConfirmDTO>> GetAdvanceOrderConfirm(int businessUnitId, List<int> titles);
		IDataResult<List<AdvanceApprovedEmployeeDTO>> GetAdvanceApproveEmployee(int advanceID, List<int> titles);
		Task<IDataResult<AdanceHistoryApproveDTO>> AddAdvanceHistoryApprove(AdanceHistoryApproveDTO dto);
	}
}
