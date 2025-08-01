using Microsoft.EntityFrameworkCore;
namespace ShortCodeGeneratorService.Models
{
    public class ShortCode
    {
        public int ShortCodeID { get; set; }   
        public string ShortCodeURL { get; set; }
        public string ShortCodeCreatedAt { get; set; }
        public string ShortCodeDescription { get; set; }
    }
}
