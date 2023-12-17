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
	}
}
