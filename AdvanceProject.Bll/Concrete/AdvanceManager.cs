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

		public async Task<IDataResult<List<AdvanceConfirmDTO>>> GetAdvanceConfirmEmployee(int employeeId)
		{
			var data = _unitOfWork.AdvanceRepository.GetAdvanceConfirmEmployee(employeeId);
			if (data == null)
			{
				return new ErrorDataResult<List<AdvanceConfirmDTO>>(null, "Data bulunamadı");
			}

			return new SuccessDataResult<List<AdvanceConfirmDTO>>(data);
		}

		public IDataResult<List<AdvanceDetailDTO>> GetAdvanceDetails(int advanceId)
		{
			var data = _unitOfWork.AdvanceRepository.GetAdvanceDetails(advanceId);
			if (data == null)
			{
				return new ErrorDataResult<List<AdvanceDetailDTO>>(null, "Data bulunamadı");
			}

			return new SuccessDataResult<List<AdvanceDetailDTO>>(data);
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

		public IDataResult<List<int>> GetTitleID(decimal advanceAmount)
		{
			var data = _unitOfWork.AdvanceRepository.GetTitleID(advanceAmount);
			if (data == null)
			{
				return new ErrorDataResult<List<int>>(null, "Data bulunamadı");
			}

			return new SuccessDataResult<List<int>>(data);
		}

		public IDataResult<List<AdvanceOrderConfirmDTO>> GetAdvanceOrderConfirm(int businessUnitId, List<int> titles)
		{
			var data = _unitOfWork.AdvanceRepository.GetAdvanceOrderConfirm(businessUnitId, titles);
			if (data == null)
			{
				return new ErrorDataResult<List<AdvanceOrderConfirmDTO>>(null, "Data bulunamadı");
			}

			return new SuccessDataResult<List<AdvanceOrderConfirmDTO>>(data);
		}


		public IDataResult<List<AdvanceApprovedEmployeeDTO>> GetAdvanceApproveEmployee(int advanceID, List<int> titles)
		{
			var data = _unitOfWork.AdvanceRepository.GetAdvanceApproveEmployee(advanceID,titles);
			if (data == null)
			{
				return new ErrorDataResult<List<AdvanceApprovedEmployeeDTO>>(null, "Data bulunamadı");
			}
			
			return new SuccessDataResult<List<AdvanceApprovedEmployeeDTO>>(data);
		}

		public async Task<IDataResult<AdanceHistoryApproveDTO>> AddAdvanceHistoryApprove(AdanceHistoryApproveDTO dto)
		{
			var advance = await _unitOfWork.AdvanceRepository.AddAdvanceHistoryApprove(dto);

			return new SuccessDataResult<AdanceHistoryApproveDTO>(advance, "Avans eklendi");
		}
	}
}
