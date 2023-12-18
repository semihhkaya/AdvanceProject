using AdvanceProject.Core.Entities;
using AdvanceProject.Dto.Advance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProject.Dal.Concrete.AdvanceRepository;

namespace AdvanceProject.Dal.Abstract
{
	public interface IAdvanceRepository
	{
		Task<Advance> AddAdvance(Advance advance);
		List<EmployeeAdvanceResponseDto> GetAdvanceListData(int employeeId);
		List<AdvanceDetailDTO> GetAdvanceDetails(int advanceId);

		List<AdvanceConfirmDTO> GetAdvanceConfirmEmployee(int employeeId);

		List<int> GetTitleID(decimal advanceAmount);
		List<AdvanceOrderConfirmDTO> GetAdvanceOrderConfirm(int businessUnitId, List<int> titles);
		List<AdvanceApprovedEmployeeDTO> GetAdvanceApproveEmployee(int advanceID, List<int> titles);

		Task<AdanceHistoryApproveDTO> AddAdvanceHistoryApprove(AdanceHistoryApproveDTO dto);


	}
}
