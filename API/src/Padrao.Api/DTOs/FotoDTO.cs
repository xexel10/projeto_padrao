using System.ComponentModel.DataAnnotations;

namespace Padrao.Api.DTOs;

public class FotoDTO
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public MultipartFormDataContent formData { get; set; }
    public string ImagemUrl { get; set; }
    public ImovelDTO Imovel { get; set; }
}
