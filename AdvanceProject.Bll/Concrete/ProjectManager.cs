using AdvanceProject.Bll.Abstract;
using AdvanceProject.Bll.Mapper;
using AdvanceProject.Core.Entities;
using AdvanceProject.Core.Result;
using AdvanceProject.Dal.UnitofWork;
using AdvanceProject.Dto.Project;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvanceProject.Bll.Concrete
{
	public class ProjectManager : IProjectManager
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly MyMapper _mapper;
		public ProjectManager(IUnitOfWork unitOfWork, MyMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public async Task<IDataResult<List<ProjectSelectDTO>>> GetAll()
		{
			var data = await _unitOfWork.ProjectRepository.GetAll();
			if (data == null)
			{
				return new ErrorDataResult<List<ProjectSelectDTO>>("Veri bulunamadı");
			}

			var entity = _mapper.Map<List<Project>, List<ProjectSelectDTO>>(data);


			return new SuccessDataResult<List<ProjectSelectDTO>>(entity);
		}
	}
}
