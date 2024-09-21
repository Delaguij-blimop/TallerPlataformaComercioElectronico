using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TallerPlataformaComercioElectronico.Models
{
    public class BillingAddress
    {
        public string Name { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public int CityId { get; set; }
    }
}
