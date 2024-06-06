using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWave.Models
{
    public class Amigo
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Usuario")]
        public int UsuarioId { get; set; }
        public virtual Usuario Usuario { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("AmigoUsuario")]
        public int AmigoId { get; set; }
        public virtual Usuario AmigoUsuario { get; set; }

        public DateTime DataAmizade { get; set; }
    }
}
