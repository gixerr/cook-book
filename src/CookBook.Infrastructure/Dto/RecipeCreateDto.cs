namespace CookBook.Infrastructure.Dto
{
    public class RecipeCreateDto
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string ShortDescription { get; set; }
        public string Preparation { get; set; }
    }
}