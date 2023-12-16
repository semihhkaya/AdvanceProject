using AdvanceProject.Bll.Abstract;
using AdvanceProject.Bll.Mapper;
using AdvanceProject.Core.Entities;
using AdvanceProject.Core.Result;
using AdvanceProject.Dal.Concrete;
using AdvanceProject.Dal.UnitofWork;
using AdvanceProject.Dto.Advance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdvanceProject.Dal.Concrete.AdvanceRepository;

namespace AdvanceProject.Bll.Concrete
{
	public class AdvanceManager : IAdvanceManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly MyMapper _mapper;
		public AdvanceManager(IUnitOfWork unitOfWork, MyMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}

		public async Task<IDataResult<AdvanceInsertDTO>> AddAdvance(AdvanceInsertDTO dto)
		{
			var entity = _mapper.Map<AdvanceInsertDTO, Advance>(dto);

			_unitOfWork.BeginTransaction();

			var advance = await _unitOfWork.AdvanceRepository.AddAdvance(entity);

			_unitOfWork.Commit(); //İçeride rollback yapıyor

			return new SuccessDataResult<AdvanceInsertDTO>(dto, "Avans eklendi");
		}



		public IDataResult<List<EmployeeAdvanceResponseDto>> GetAdvanceListData(int employeeId)
		{
			var data = _unitOfWork.AdvanceRepository.GetAdvanceListData(employeeId);
			if (data == null)
			{
				return new ErrorDataResult<List<EmployeeAdvanceResponseDto>>(null,"Data bulunamadı");
			}

			return new SuccessDataResult<List<EmployeeAdvanceResponseDto>>(data);
		}
	}
}
