
using System.ComponentModel.DataAnnotations;

namespace Padrao.Business.Models;
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
