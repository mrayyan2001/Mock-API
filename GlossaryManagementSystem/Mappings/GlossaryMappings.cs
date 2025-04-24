using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlossaryManagementSystem.DTOs.GlossaryItem;
using GlossaryManagementSystem.Models;

namespace GlossaryManagementSystem.Mappings
{
    public static class GlossaryMappings
    {
        public static GlossaryItemDTO ToDto(this GlossaryItem entity)
        {
            return new GlossaryItemDTO()
            {
                Id = entity.Id,
                Term = entity.Term,
            };
        }
        public static GlossaryItemDetailsDto ToDetailsDto(this GlossaryItem entity)
        {
            return new GlossaryItemDetailsDto()
            {
                Id = entity.Id,
                Term = entity.Term,
                Definition = entity.Definition
            };
        }
        public static GlossaryItem ToEntity(this CreateGlossaryItemDTO dto)
        {
            return new GlossaryItem()
            {
                Term = dto.Term,
                Definition = dto.Definition
            };
        }
        public static GlossaryItem ToEntity(this UpdateGlossaryItemDTO dto)
        {
            return new GlossaryItem()
            {
                Term = dto.Term,
                Definition = dto.Definition
            };
        }
    }
}