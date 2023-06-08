﻿using System.ComponentModel.DataAnnotations;

namespace WebAppTest.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public string? Address { get; set; }

        [Required]
        public string Maneger { get; set; }

    }
}
