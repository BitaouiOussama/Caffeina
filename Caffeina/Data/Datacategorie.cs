using System;
using Caffeina.Models;
namespace Caffeina.Data
{
	public class Datacategorie
	{
		private static List<Categorie> categories = new List<Categorie>
		{
			new Categorie{IdCateg=1,Designation="",DateAjout=new DateTime()},
			new Categorie{IdCateg=2,Designation="",DateAjout=new DateTime()},
			new Categorie{IdCateg=3,Designation="",DateAjout=new DateTime()}
		};

		public Datacategorie(){}

		public static List<Categorie> getListes()
		{
			return categories;
        }
	}
}

