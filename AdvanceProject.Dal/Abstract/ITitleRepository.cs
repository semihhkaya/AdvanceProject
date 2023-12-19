using AdvanceProject.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Abstract
{
	public interface ITitleRepository
	{
		Task<List<Title>> GetAll();
	}
}
