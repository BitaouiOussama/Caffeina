using System;
using Caffeina.Models;
using Microsoft.EntityFrameworkCore;

namespace Caffeina.Data
{
	public class DataDbContext : DbContext
	{
		public  DbSet<Categorie> categories {  get; set; }
		public DbSet<Produit> produits { get; set; }


        public DataDbContext(DbContextOptions<DataDbContext>options) : base(options){
		
		}

		/*public static List<Categorie> getListes()
		{
			return categories;
        }*/
	}
}

