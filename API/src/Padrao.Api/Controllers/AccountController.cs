using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProEventos.Application.Contratos;
using Padrao.Api.DTOs;
using Padrao.Api.Contratos;
using ProEventos.API.Extensions;

namespace Padrao.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;
        
        private readonly string _destino = "Perfil";

        public AccountController(IAccountService accountService,
                                 ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser()
        {
            try
            {
                var userName = User.GetUserName();
                var user = await _accountService.GetUserByUserNameAsync(userName);
                return Ok(user);
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar recuperar Usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UserDTO userDto)
        {
            try
            {
                if (await _accountService.UserExists(userDto.UserName))
                    return BadRequest("Usuário já existe");

                var user = await _accountService.CreateAccountAsync(userDto);
                if (user != null)
                    return Ok(new
                    {
                        userName = user.UserName,
                        firstName = user.FirstName,
                        lastName = user.LastName,
                        imageUrl = user.ImageURL,
                        token = _tokenService.CreateToken(user).Result
                    });

                return BadRequest("Usuário não criado, tente novamente mais tarde!");
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Registrar Usuário. Erro: {ex.Message}");
            }
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserLoginDTO userLogin)
        {
            try
            {
                var user = await _accountService.GetUserByUserNameAsync(userLogin.Username);
                if (user == null) return Unauthorized("Usuário ou Senha está errado");

                var result = await _accountService.CheckUserPasswordAsync(user, userLogin.Password);
                if (!result.Succeeded) return Unauthorized();

                return Ok(new
                {
                    userName = user.UserName,
                    PrimeroNome = user.FirstName,
                    token = _tokenService.CreateToken(user).Result
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar realizar Login. Erro: {ex.Message}");
            }
        }

        [HttpPut("UpdateUser")]
        public async Task<IActionResult> UpdateUser(UserUpdateDTO userUpdateDto)
        {
            try
            {
                if (userUpdateDto.UserName != User.GetUserName())
                    return Unauthorized("Usuário Inválido");

                var user = await _accountService.GetUserByUserNameAsync(User.GetUserName());
                if (user == null) return Unauthorized("Usuário Inválido");

                var userReturn = await _accountService.UpdateAccount(userUpdateDto);
                if (userReturn == null) return NoContent();

                return Ok(new
                {
                    userName = userReturn.UserName,
                    PrimeroNome = userReturn.FirstName,
                    token = _tokenService.CreateToken(userReturn).Result
                });
            }
            catch (Exception ex)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,
                    $"Erro ao tentar Atualizar Usuário. Erro: {ex.Message}");
            }
        }

    }
}