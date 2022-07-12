using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IceCubey_DataAccess
{
    public class Income
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsCommon { get; set; } //Common income such as pay
        public bool IsUncommon { get; set; } //Income that simply is uncommon
        public DateTime Date { get; set; }
        public string? ImageUrl { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
    }
}
