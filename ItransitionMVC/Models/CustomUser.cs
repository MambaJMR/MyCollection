using ItransitionMVC.Models.Collection;
using Microsoft.AspNetCore.Identity;

namespace ItransitionMVC.Models
{
    public  class CustomUser : IdentityUser
    {
        public List<CustomCollection> Collections { get; set; }
    }
}
