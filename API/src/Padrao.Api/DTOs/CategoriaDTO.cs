using System.ComponentModel.DataAnnotations;

namespace Padrao.Api.DTOs
{
    public class CategoriaDTO
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public bool Status { get; set; }


    }
}

