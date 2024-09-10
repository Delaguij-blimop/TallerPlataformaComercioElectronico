using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerPlataformaComercioElectronico.Models
{
    public class PaymentErrorResponse
    {
        public string Status { get; set; }
        public string ErrorCode { get; set; }
        public string Message { get; set; }
    }
}
