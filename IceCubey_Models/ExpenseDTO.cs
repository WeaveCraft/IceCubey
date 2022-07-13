using System.ComponentModel.DataAnnotations;

namespace IceCubey_Models
{
    public class ExpenseDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsCommon { get; set; } //Common income such as pay
        public bool IsUncommon { get; set; } //Income that simply is uncommon
        [Required]
        public DateTime Date { get; set; }
        public string? ImageUrl { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int ExpenseCategoryId { get; set; }
        public ExpenseCategoryDTO ExpenseCategory { get; set; }
    }
}
