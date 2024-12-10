namespace DotNetWebDemo.Models
{
    public class Dish
    {
        public int Id { get; set; }
        public string Name {get; set;} 
        public string ImageUrl {get; set;}
        public double price{get; set;}
        public List<DishIngredient> dishIngredients {get; set;}  

    }
}