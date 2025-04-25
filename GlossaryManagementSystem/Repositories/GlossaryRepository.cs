using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlossaryManagementSystem.Data;
using GlossaryManagementSystem.Interfaces;
using GlossaryManagementSystem.Models;

namespace GlossaryManagementSystem.Repositories
{
    public class GlossaryRepository : IGlossaryRepository
    {

        private readonly GlossaryDbContext _context;

        public GlossaryRepository(GlossaryDbContext context)
        {
            _context = context;
        }

        public async Task<List<GlossaryItem>> GetAll()
            => await Task.FromResult(_context.GlossaryItems);
        public async Task<GlossaryItem?> GetById(int id)
            => await Task.FromResult(_context.GlossaryItems.FirstOrDefault(i => i.Id == id));
        public async Task<GlossaryItem> Add(GlossaryItem item)
        {
            item.Id = _context.GlossaryItems.Count == 0 ? 1 : _context.GlossaryItems.Max(i => i.Id) + 1;
            _context.GlossaryItems.Add(item);
            _context.SaveChanges();
            return await Task.FromResult(item);
        }
        public async Task<GlossaryItem?> Delete(int id)
        {
            var exist = _context.GlossaryItems.FirstOrDefault(i => i.Id == id);
            if (exist is null)
                return null;
            _context.GlossaryItems.Remove(exist);
            _context.SaveChanges();
            return await Task.FromResult(exist);
        }
        public async Task<bool> Exists(string term)
            => await Task.FromResult(_context.GlossaryItems.Any(i => i.Term == term));
        public async Task<GlossaryItem?> Update(GlossaryItem item)
        {
            var existing = _context.GlossaryItems.FirstOrDefault(i => i.Id == item.Id);
            if (existing is null)
                return null;
            existing.Term = item.Term;
            existing.Definition = item.Definition;
            _context.SaveChanges();
            return await Task.FromResult(existing);
        }

    }
}