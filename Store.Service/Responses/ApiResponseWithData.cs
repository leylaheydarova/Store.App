using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Service.Responses
{
    public class ApiResponseWithData:ApiResponse
    {
        public object Datas { get; set; }
    }
}
