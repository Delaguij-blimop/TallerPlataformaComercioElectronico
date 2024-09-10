using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerPlataformaComercioElectronico.Models
{
    public class PaymentServiceResponse
    {
        public string Status { get; set; } // "success" o "failure"
        public string TransactionId { get; set; } // Solo para éxito
        public decimal Amount { get; set; } // Solo para éxito
        public string Currency { get; set; } // Solo para éxito
        public string OrderId { get; set; } // Solo para éxito
        public string Message { get; set; } // Para éxito o error
        public string ErrorCode { get; set; } // Solo para errores
    }
}
