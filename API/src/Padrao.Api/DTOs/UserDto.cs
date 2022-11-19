using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Padrao.Api.DTOs
{
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageURL { get; set; }
    }
}