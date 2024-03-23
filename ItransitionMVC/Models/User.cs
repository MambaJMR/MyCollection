using Microsoft.AspNetCore.Identity;

namespace ItransitionMVC.Models
{
    public class User : IdentityUser
    {
        public List<CustomCollection> Collections { get; set; }
    }
}
