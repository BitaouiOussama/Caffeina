using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caffeina.Models
{
    public partial class Commande
    {
        public Commande()
        {
            ArticlesCommandes = new HashSet<ArticlesCommande>();
        }

        [Key]
        public int IdCommande { get; set; }
        public int? IdUtilisateur { get; set; }
        public DateTime DateCommande { get; set; }

        public virtual Utilisateur? IdUtilisateurNavigation { get; set; }
        public virtual ICollection<ArticlesCommande> ArticlesCommandes { get; set; }
    }
}
