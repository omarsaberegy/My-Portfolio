namespace Core.Entities
{
    public class PotfolioItem :EntityBase
    {
        public string ProjectName { get; set; }
        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
