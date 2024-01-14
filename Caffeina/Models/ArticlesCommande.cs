using System;
using System.Collections.Generic;

namespace Caffeina.Models
{
    public partial class ArticlesCommande
    {
        public int IdArticle { get; set; }
        public int? IdCommande { get; set; }
        public int? IdProduit { get; set; }
        public int Quantite { get; set; }

        public virtual Commande? IdCommandeNavigation { get; set; }
        public virtual Produit? IdProduitNavigation { get; set; }
    }
}
