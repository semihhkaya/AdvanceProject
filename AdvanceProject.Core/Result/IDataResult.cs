using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Result
{
	public interface IDataResult<T>:IResult
	{
		//IResult implemantastonu ile succes ve message'ı alıyoruz.
	 //Hem success hem message hem de veri dönüdren işlemler için bu result kullanılır. IResult void işlemler içindir.(ör.Add)
		T Data { get; }
	}
}
