using System;
using System.ComponentModel.DataAnnotations;

namespace Caffeina.Models
{
	public class Categorie
	{
		public Categorie(){}
        [Key]
        public int IdCateg{ get; set; }

        public string Designation{ get; set; }

        public string ImageSource { get; set; }

        public DateTime DateAjout { get; set; }
    }
}

