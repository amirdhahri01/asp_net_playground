using System.Diagnostics;
using DotNetWebDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetWebDemo.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }  
        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.Entity<DishIngredient>().HasKey(di => new {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.Dish).WithMany(di => di.dishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredient>().HasOne(d => d.ingredient).WithMany(di => di.dishIngredients).HasForeignKey(d => d.IngredientId);
            modelBuilder.Entity<Dish>().HasData(new Dish {Id =1 , Name="Margheritta" , price=7.82,ImageUrl="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcRd6jONKGIT4J-tBAzmZsP0sP9PU7oVV2Oc7Q&s"});
            modelBuilder.Entity<Ingredient>().HasData(new Ingredient {Id =1 , Name="Tomato Sauce"} , 
                                                        new Ingredient {Id =2 , Name="Mozzarella"} );
            modelBuilder.Entity<DishIngredient>().HasData(
                new DishIngredient{DishId =1 , IngredientId=1},
                new DishIngredient{DishId =1 , IngredientId=2}
            );
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<DishIngredient> DishIngredients{ get; set; }
        public DbSet<Ingredient> Ingredients {get; set;}
    }
}