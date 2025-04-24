using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GlossaryManagementSystem.Interfaces;
using GlossaryManagementSystem.Models;

namespace GlossaryManagementSystem.Repositories
{
    public class GlossaryRepository : IGlossaryRepository
    {

        private readonly List<GlossaryItem> _items = new List<GlossaryItem>()
        {
            new GlossaryItem { Id = 1, Term = "API", Definition = "A set of functions that allows applications to access data and interact with external software components or services." },
            new GlossaryItem { Id = 2, Term = "HTTP", Definition = "HyperText Transfer Protocol, the foundation of data communication for the World Wide Web." },
            new GlossaryItem { Id = 3, Term = "JSON", Definition = "JavaScript Object Notation, a lightweight data-interchange format that's easy for humans to read and write." },
            new GlossaryItem { Id = 4, Term = "REST", Definition = "Representational State Transfer, an architectural style for designing networked applications." },
            new GlossaryItem { Id = 5, Term = "DTO", Definition = "Data Transfer Object, a design pattern used to transfer data between software application subsystems." },
            new GlossaryItem { Id = 6, Term = "Entity Framework", Definition = "An open-source object-relational mapping framework for ADO.NET, part of the .NET framework." },
            new GlossaryItem { Id = 7, Term = "Middleware", Definition = "Software that acts as a bridge between an operating system or database and applications, especially on a network." },
            new GlossaryItem { Id = 8, Term = "Routing", Definition = "The process of directing an HTTP request to the appropriate controller and action method in a web application." },
            new GlossaryItem { Id = 9, Term = "CORS", Definition = "Cross-Origin Resource Sharing, a mechanism that allows resources on a web page to be requested from another domain." },
            new GlossaryItem { Id = 10, Term = "Dependency Injection", Definition = "A design pattern that allows a class to receive its dependencies from external sources rather than creating them itself." }
        };

        public async Task<List<GlossaryItem>> GetAll()
            => await Task.FromResult(_items);
        public async Task<GlossaryItem?> GetById(int id)
            => await Task.FromResult(_items.FirstOrDefault(i => i.Id == id));
        public async Task<GlossaryItem> Add(GlossaryItem item)
        {
            item.Id = _items.Count == 0 ? 1 : _items.Max(i => i.Id) + 1;
            _items.Add(item);
            return await Task.FromResult(item);
        }
        public async Task<GlossaryItem?> Delete(int id)
        {
            var exist = _items.FirstOrDefault(i => i.Id == id);
            if (exist is null)
                return null;
            _items.Remove(exist);
            return await Task.FromResult(exist);
        }
        public async Task<bool> Exists(int id)
            => await Task.FromResult(_items.Any(i => i.Id == id));
        public async Task<GlossaryItem?> Update(GlossaryItem item)
        {
            var existing = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existing is null)
                return null;
            existing.Term = item.Term;
            existing.Definition = item.Definition;

            return await Task.FromResult(existing);
        }

    }
}