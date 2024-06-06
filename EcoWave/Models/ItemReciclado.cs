using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWave.Models
{
    public class ItemReciclado
    {
        [Key]
        public int ItemId { get; set; }

        [Required, ForeignKey("Usuario")]
        public int UsuarioId { get; set; }

        [Required, MaxLength(50)]
        public string TipoItem { get; set; }

        [Required]
        public DateTime DataColeta { get; set; }

        [MaxLength(100)]
        public string Localizacao { get; set; }

        [Required]
        public int Quantidade { get; set; }

        public virtual Usuario? Usuario { get; set; }
    }
}
