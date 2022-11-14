namespace Padrao.Business.Models;
public class Foto : Entity
{
    public string Descricao { get; set; }
    public string ImagemUrl { get; set; }
    public Imovel Imovel { get; set; }

}


