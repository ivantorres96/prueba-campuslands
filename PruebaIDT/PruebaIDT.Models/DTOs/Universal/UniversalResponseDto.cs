using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PruebaIDT.Models.DTOs.Universal
{
    public class UniversalResponseDto<T>
    {
        public T? Data { get; set; }
        public HttpStatusCode Code { get; set; }
    }   
}
