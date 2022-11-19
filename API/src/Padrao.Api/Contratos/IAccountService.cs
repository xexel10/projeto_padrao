using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Padrao.Api.DTOs;

namespace Padrao.Api.Contratos
{
    public interface IAccountService
    {
        Task<bool> UserExists(string username);
        Task<UserUpdateDTO> GetUserByUserNameAsync(string username);
        Task<SignInResult> CheckUserPasswordAsync(UserUpdateDTO userUpdateDto, string password);
        Task<UserUpdateDTO> CreateAccountAsync(UserDTO userDto);
        Task<UserUpdateDTO> UpdateAccount(UserUpdateDTO userUpdateDto);
    }
}