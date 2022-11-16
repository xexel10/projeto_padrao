using System.ComponentModel.DataAnnotations;

namespace Padrao.Api.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }


    }
}

