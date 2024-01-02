using System;
using System.ComponentModel.DataAnnotations;

namespace Caffeina.Models
{
	public class Produit
	{
		public Produit(){}

		[Key]
		public int IdProd{ get; set; }

		public string Labelle{ get; set; }

		public double Prix{ get; set; }

		public int IdCateg{ get; set; }

		public string ImageSource { get; set; }

        public DateTime DateAjout { get; set; }
	}
}

