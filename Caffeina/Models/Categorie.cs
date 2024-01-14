using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Caffeina.Models
{
    public partial class Categorie
    {
        public Categorie()
        {
            Produits = new HashSet<Produit>();
        }

        [Key]
        public int IdCategorie { get; set; }
        public string Designation { get; set; } = null!;
        public string SourceImage { get; set; } = null!;
        public DateTime? DateAjout { get; set; }

        public virtual ICollection<Produit> Produits { get; set; }
    }
}
