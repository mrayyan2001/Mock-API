using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlossaryManagementSystem.Models;

namespace GlossaryManagementSystem.Interfaces
{
    public interface IGlossaryRepository
    {
        public Task<List<GlossaryItem>> GetAll();
        public Task<GlossaryItem?> GetById(int id);
        public Task<GlossaryItem> Add(GlossaryItem item);
        public Task<GlossaryItem?> Update(GlossaryItem item);
        public Task<GlossaryItem?> Delete(int id);
        public Task<bool> Exists(string term);
    }
}