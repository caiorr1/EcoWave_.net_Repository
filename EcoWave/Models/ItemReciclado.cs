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
        public DateTime DataColeta { get; set; } = DateTime.Now;
        [MaxLength(100)]
        public string Localizacao { get; set; }
        [Required]
        public int Quantidade { get; set; }

        public Usuario Usuario { get; set; }
    }
}
