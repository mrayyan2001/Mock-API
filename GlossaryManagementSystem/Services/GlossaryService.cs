using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlossaryManagementSystem.DTOs.GlossaryItem;
using GlossaryManagementSystem.Interfaces;
using GlossaryManagementSystem.Mappings;

namespace GlossaryManagementSystem.Services
{
    public class GlossaryService : IGlossaryService
    {

        private readonly IGlossaryRepository _glossaryRepo;

        public GlossaryService(IGlossaryRepository glossaryRepo)
        {
            _glossaryRepo = glossaryRepo;
        }
        public async Task<GlossaryItemDTO> Add(CreateGlossaryItemDTO item)
        {
            // TODO - Handle busies logic (Term should be unique)
            if (await _glossaryRepo.Exists(item.Term))
            {
                throw new Exception($"Term {item.Term} is already exists.");
            }
            return (await _glossaryRepo.Add(item.ToEntity())).ToDto();
        }
        public async Task<List<GlossaryItemDTO>> GetAll()
        {
            return (await _glossaryRepo.GetAll()).Select(i => i.ToDto()).ToList();
        }
        public async Task<GlossaryItemDetailsDto?> GetById(int id)
            => (await _glossaryRepo.GetById(id))?.ToDetailsDto();
        public async Task<GlossaryItemDetailsDto?> Update(int id, UpdateGlossaryItemDTO item)
        {
            var updated = await _glossaryRepo.Update(item.ToEntity(id));
            if (updated is null)
            {
                return null;
            }
            return updated.ToDetailsDto();
        }
    }
}