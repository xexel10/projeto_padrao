namespace Padrao.Business.Models;
public class Imovel : Entity
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public TipoImovel TipoImovel { get; set; }
    public Categoria Categoria { get; set; }
    public IEnumerable<Foto> Fotos { get; set; }

}
