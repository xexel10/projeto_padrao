using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Padrao.Business.Models.Identity;
using Padrao.Data.Context;
using Padrao.Business.Interfaces;

namespace Padrao.Data.Repository
{
    public class UserPersist : GeralPersist, IUserPersist
    {
        private readonly MeuDbContext _context;

        public UserPersist(MeuDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> GetUserByUserNameAsync(string userName)
        {
            return await _context.Users
                                 .SingleOrDefaultAsync(user => user.UserName == userName.ToLower());
        }
    }
}