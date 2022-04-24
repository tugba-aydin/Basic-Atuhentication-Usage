
using System.ComponentModel.DataAnnotations;

namespace BasicAuthenticationExample.Entities
{
    public class User
    {
        public int Id { get; set; }

        //[Display(Name = "User Id")]
        //public string UserId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
