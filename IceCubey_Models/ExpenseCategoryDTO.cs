using System.ComponentModel.DataAnnotations;

namespace IceCubey_Models
{
    public class ExpenseCategoryDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter a Name")]
        public string? Name { get; set; }
    }
}
