using System.ComponentModel.DataAnnotations;

namespace UdemyMicroservice.Discount.API.Options
{
    public class MongoOption
    {
        [Required]
        public string DatabaseName { get; set; } = default!; 
        [Required]
        public string ConnectionString { get; set; } = default!;
    }
}
