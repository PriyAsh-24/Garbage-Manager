using System.ComponentModel.DataAnnotations;

namespace GarbageManager.Models
{
    public class Garbage
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type {  get; set; }
        [Required(ErrorMessage ="Quantity is Required")]
        public int Quantity {  get; set; }
        public decimal TotalPrice { get; set; }
    }
}
