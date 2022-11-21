using Padrao.Api.DTOs;

namespace Padrao.Api.Services.Contratos
{
    public interface ITokenService
    {
        Task<string> CreateToken(UserUpdateDTO userUpdateDto);
    }
}