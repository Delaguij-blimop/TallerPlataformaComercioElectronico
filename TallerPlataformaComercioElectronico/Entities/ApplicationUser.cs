using Microsoft.AspNetCore.Identity;

namespace TallerPlataformaComercioElectronico.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public bool FraudReport { get; set; }
        public bool IsAdmin { get; set; }
    }
}
