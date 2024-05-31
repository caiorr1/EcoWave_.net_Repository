using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWave.Models
{
    public class Recompensa
    {
        [Key]
        public int recompensa_id { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public int usuario_id { get; set; }
        [Required]
        public int pontos { get; set; }
        [Required]
        [MaxLength(50)]
        public string tipo_recompensa { get; set; }
        public DateTime? data_resgate { get; set; }

        public Usuario Usuario { get; set; }
    }
}
