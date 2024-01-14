using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caffeina.Models
{
    public partial class Utilisateur
    {
        public Utilisateur()
        {
            Commandes = new HashSet<Commande>();
        }

        [Key]
        public int IdUtilisateur { get; set; }
        public string Nom { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string MotDePasse { get; set; } = null!;

        public virtual ICollection<Commande> Commandes { get; set; }
    }
}
