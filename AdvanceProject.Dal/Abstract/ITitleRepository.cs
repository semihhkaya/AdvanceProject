using AdvanceProject.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Dal.Abstract
{
	public interface ITitleRepository
	{
		Task<List<Title>> GetAll();
	}
}
