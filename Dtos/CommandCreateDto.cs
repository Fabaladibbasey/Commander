using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos
{
    public class CommandCreateDto
    {

        // [Required]
        // public int Id { get; set; }

        [Required]
        public string HowTo { get; set; }

        [Required]
        [MaxLength(25)]
        public string Line { get; set; }

        [Required]
        [MaxLength(25)]
        public string Platform { get; set; }
    }
}