using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Padrao.Business.Models.Identity;

public class User : IdentityUser<int>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ImageURL { get; set; }
    public IEnumerable<UserRole> UserRoles { get; set; }
}
