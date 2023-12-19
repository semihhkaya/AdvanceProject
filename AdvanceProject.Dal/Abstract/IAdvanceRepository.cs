using AdvanceProject.Core.Entities;
using AdvanceProject.Dto.Advance;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Abstract
{
	public interface IAdvanceRepository
	{
		Task<Advance> AddAdvance(Advance advance);
		//bekleyen avanslar
		List<EmployeeAdvanceResponseDto> GetAdvanceListData(int employeeId);
		//avansın detayları
		List<AdvanceDetailDTO> GetAdvanceDetails(int advanceId);

		List<AdvanceConfirmDTO> GetAdvanceConfirmEmployee(int employeeId);

		List<int> GetTitleID(decimal advanceAmount);
		List<AdvanceOrderConfirmDTO> GetAdvanceOrderConfirm(int businessUnitId, List<int> titles);
		List<AdvanceApprovedEmployeeDTO> GetAdvanceApproveEmployee(int advanceID, List<int> titles); //Onaylayacak çalışanlar

		//Onayda kullanılan
		Task<AdanceHistoryApproveDTO> AddAdvanceHistoryApprove(AdanceHistoryApproveDTO dto);
		Task<bool> GetAdvanceChangeStatus(int advanceId, int nowStatus);
		//Onay bekleyen avanslar page
		Task<List<UserAdvanceListDTO>> GetUserAdvanceList(int employeeId, int businessUnitID);
	}
}
