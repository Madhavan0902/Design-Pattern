using System.ComponentModel.DataAnnotations;
namespace ShortCodeGeneratorService.Models
{
    public class ShortCode
    {
        [Key]
        public int ShortCodeID { get; set; } = 0;
        [Required]
        public string ShortCodeURL { get; set; } = string.Empty;
        [Required]
        public string ShortCodeCreatedAt { get; set;} = string.Empty;
        [Required]
        public string ShortCodeDescription { get; set; } = string.Empty;
    }
}
