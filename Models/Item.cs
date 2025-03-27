using System.ComponentModel.DataAnnotations;

namespace SimpleApi.Models
{
    public class Item
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El nombre es obligatorio...")]
        public required string Name { get; set; }
    }
}