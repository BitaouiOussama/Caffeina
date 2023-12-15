using System;
using Caffeina.Models;
namespace Caffeina.Data
{
	public class Dataproduit
	{
		private static List<Produit> produits = new List<Produit>
		{
			new Produit{IdProd=1, Labelle="Produit", Prix=100.01, DateAjout=new DateTime(), IdCateg=1}
		};
		public Dataproduit()
		{
		}

		public static List<Produit> getListes()
		{
			return produits;

        }
	}
}

