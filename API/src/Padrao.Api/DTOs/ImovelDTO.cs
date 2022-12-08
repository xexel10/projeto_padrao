namespace Padrao.Api.DTOs;
public class ImovelDTO
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int CategoriaId { get; set; }
    public int TipoImovelId { get; set; }
    public TipoImovelDTO TipoImovel { get; set; }
    public CategoriaDTO Categoria { get; set; }
    public IEnumerable<FotoDTO> Fotos { get; set; }
}