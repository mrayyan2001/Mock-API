using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GlossaryManagementSystem.DTOs.GlossaryItem
{
    public class CreateGlossaryItemDTO
    {
        [Required]
        public string Term { get; set; } = string.Empty;
        [Required]
        public string Definition { get; set; } = string.Empty;
    }
}