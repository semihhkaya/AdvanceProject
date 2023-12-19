using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdvanceProject.API.Model
{
	public class ErrorResponseModel
	{
        public int StatusCode { get; set; }
        public string Message { get; set; }

        public override string ToString()
        {
            return $"{{\"statusCode\": {StatusCode}, \"message\": \"{Message}\"}}";
        }
    }
}
