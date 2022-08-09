using Microsoft.AspNetCore.Identity;

namespace CqrsExample.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

}
