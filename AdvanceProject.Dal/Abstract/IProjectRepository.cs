using AdvanceProject.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Abstract
{
	public interface IProjectRepository
	{
		Task<List<Project>> GetAll();
	}
}
