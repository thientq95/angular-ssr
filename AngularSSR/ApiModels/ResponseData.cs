using SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularSSR.ApiModels
{
    public class ResponseData<T> where T: BaseEntity
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
