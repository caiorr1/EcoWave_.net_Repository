using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWave.Models
{
    public class ItemReciclado
    {
        [Key]
        public int item_id { get; set; }
        [Required]
        [ForeignKey("Usuario")]
        public int usuario_id { get; set; }
        [Required]
        [MaxLength(50)]
        public string tipo_item { get; set; }
        public DateTime data_coleta { get; set; } = DateTime.Now;
        [MaxLength(100)]
        public string localizacao { get; set; }
        [Required]
        public int quantidade { get; set; }

        public Usuario Usuario { get; set; }
    }
}
