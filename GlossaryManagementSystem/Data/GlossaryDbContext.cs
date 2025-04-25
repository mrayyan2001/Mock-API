using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GlossaryManagementSystem.Models;

namespace GlossaryManagementSystem.Data
{
    public class GlossaryDbContext
    {
        private readonly string _filePath = "./Data/glossary.json";

        public List<GlossaryItem> GlossaryItems { get; set; }

        public GlossaryDbContext()
        {
            GlossaryItems = LoadItems();
        }

        private List<GlossaryItem> LoadItems()
        {
            if (!File.Exists(_filePath))
                return new List<GlossaryItem>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<GlossaryItem>>(json) ?? new List<GlossaryItem>();
        }

        public void SaveChanges()
        {
            var json = JsonSerializer.Serialize(GlossaryItems, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }
    }

}