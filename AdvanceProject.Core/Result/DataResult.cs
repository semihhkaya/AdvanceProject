using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceProject.Core.Result
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        //hem olumlu-olumsuz hem de bir mesaj gönderir.
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data; 
        }

        public DataResult(T data, bool success) : base(success) 
        {
            Data = data;
        }
        public T Data { get; }
    }
}
