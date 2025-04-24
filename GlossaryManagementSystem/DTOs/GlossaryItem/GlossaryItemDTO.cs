using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlossaryManagementSystem.DTOs.GlossaryItem
{
    public class GlossaryItemDTO
    {
        public int Id { get; set; }
        public string Term { get; set; } = string.Empty;
        public string Definition { get; set; } = string.Empty;
    }
}