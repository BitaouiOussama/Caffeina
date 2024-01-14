using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caffeina.Models
{
    public partial class Produit
    {
        public Produit()
        {
            ArticlesCommandes = new HashSet<ArticlesCommande>();
        }

        [Key]
        public int IdProduit { get; set; }
        public string NomProduit { get; set; } = null!;
        public string? Description { get; set; }
        public string SourceImage { get; set; } = null!;
        public decimal Prix { get; set; }
        public int Stock { get; set; }
        public int? IdCategorie { get; set; }

        public virtual Categorie? IdCategorieNavigation { get; set; }
        public virtual ICollection<ArticlesCommande> ArticlesCommandes { get; set; }
    }
}
