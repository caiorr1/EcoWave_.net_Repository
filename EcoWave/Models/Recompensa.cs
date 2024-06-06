using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWave.Models
{
    public class Recompensa
    {
        [Key]
        public int RecompensaId { get; set; }

        [Required, ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Required]
        public int Pontos { get; set; }

        [Required, MaxLength(50)]
        public string TipoRecompensa { get; set; }

        public DateTime? DataResgate { get; set; }
    }
}
