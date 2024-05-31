using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcoWave.Models
{
    public class Amigo
    {
        [ForeignKey("Usuario")]
        public int usuario_id { get; set; }
        [ForeignKey("Usuario")]
        public int amigo_id { get; set; }
        public DateTime data_amizade { get; set; } = DateTime.Now;

        public Usuario Usuario { get; set; }
        public Usuario AmigoUsuario { get; set; }
    }
}
