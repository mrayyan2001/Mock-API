using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlossaryManagementSystem.DTOs.GlossaryItem
{
    public class UpdateGlossaryItemDTO
    {
        public string Term { get; set; } = string.Empty;
        public string Definition { get; set; } = string.Empty;
    }
}