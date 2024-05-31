using System;

namespace EcoWave.Models
{
    public class Amigo
    {
        public int UsuarioId { get; set; }
        public int AmigoId { get; set; }
        public DateTime DataAmizade { get; set; } = DateTime.Now;

        public Usuario Usuario { get; set; }
        public Usuario AmigoUsuario { get; set; }
    }
}
