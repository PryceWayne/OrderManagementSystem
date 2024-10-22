﻿using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystem.Models
{
    public class Cost
    {
        [Key]
        public string Cost_ID { get; set; } // Primary key

        public double Amount { get; set; }

        [StringLength(255)]
        public string Description { get; set; }
    }
}