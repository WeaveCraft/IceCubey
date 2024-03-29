﻿using System.ComponentModel.DataAnnotations;

namespace IceCubey_Models
{
    public class IncomeDTO
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsCommon { get; set; } //Common income such as pay
        public bool IsUncommon { get; set; } //Income that simply is uncommon
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string? ImageUrl { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "Please select a category")]
        public int CategoryId { get; set; }
        public CategoryDTO Category { get; set; }
    }
}