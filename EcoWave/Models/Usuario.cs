using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EcoWave.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioId { get; set; }

        [Required, MaxLength(50)]
        public string NomeUsuario { get; set; }

        [Required, MaxLength(256)]
        public string SenhaHash { get; set; }

        [Required, MaxLength(100)]
        public string Email { get; set; }

        public DateTime DataRegistro { get; set; }

        [MaxLength(100)]
        public string Localizacao { get; set; }

        [MaxLength(256)]
        public string FotoPerfil { get; set; }

        public virtual ICollection<Amigo> Amigos { get; set; }
        public virtual ICollection<Amigo> AmigosDoUsuario { get; set; }
        public virtual ICollection<Recompensa> Recompensas { get; set; }
        public virtual ICollection<ItemReciclado> ItensReciclados { get; set; }
        public virtual ICollection<ReconhecimentoItem> ReconhecimentoItens { get; set; }
        public virtual ICollection<Configuracao> Configuracoes { get; set; }

        public Usuario()
        {
            Amigos = new HashSet<Amigo>();
            AmigosDoUsuario = new HashSet<Amigo>();
            Recompensas = new HashSet<Recompensa>();
            ItensReciclados = new HashSet<ItemReciclado>();
            ReconhecimentoItens = new HashSet<ReconhecimentoItem>();
            Configuracoes = new HashSet<Configuracao>();
        }
    }
}
