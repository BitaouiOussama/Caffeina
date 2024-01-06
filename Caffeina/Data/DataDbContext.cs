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

     /*   protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produit>()
                .Property(p => p.ImageSource)
                .HasColumnType("VARBINARY(MAX)");

            // Vous pouvez ajouter d'autres configurations de modèle ici, le cas échéant

            base.OnModelCreating(modelBuilder);
        }*/

        /*		public static List<Categorie> getListes()
                {
                    return categories;
                }*/

    }
}

