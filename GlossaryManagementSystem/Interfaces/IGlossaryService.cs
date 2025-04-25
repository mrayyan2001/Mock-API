using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlossaryManagementSystem.DTOs.GlossaryItem;

namespace GlossaryManagementSystem.Interfaces
{
    public interface IGlossaryService
    {
        public Task<List<GlossaryItemDTO>> GetAll();
        public Task<GlossaryItemDetailsDto?> GetById(int id);
        public Task<GlossaryItemDetailsDto> Add(CreateGlossaryItemDTO item);
        public Task<GlossaryItemDetailsDto?> Update(int id, UpdateGlossaryItemDTO item);
    }
}