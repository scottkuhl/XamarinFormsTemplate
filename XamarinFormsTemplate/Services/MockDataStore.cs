using Ardalis.GuardClauses;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using XamarinFormsTemplate.Models;

namespace XamarinFormsTemplate.Services
{
    public class MockDataStore : IDataStore<Item>
    {
        private readonly List<Item> items;

        public MockDataStore()
        {
            items = new List<Item>()
            {
                new Item { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description.", AddedOn = DateTime.Now.AddDays(-6) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description.", AddedOn = DateTime.Now.AddDays(-5) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description.", AddedOn = DateTime.Now.AddDays(-4) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description.", AddedOn = DateTime.Now.AddDays(-3) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description.", AddedOn = DateTime.Now.AddDays(-2) },
                new Item { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description.", AddedOn = DateTime.Now.AddDays(-1) }
            };
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            Guard.Against.Null(item, nameof(item));

            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            var oldItem = items.Find((Item arg) => arg.Id == id);
            items.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Item> GetItemAsync(string id)
        {
            Guard.Against.NullOrEmpty(id, nameof(id));

            return await Task.FromResult(items.Find(s => s.Id == id));
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }

        public async Task<bool> UpdateItemAsync(Item item)
        {
            Guard.Against.Null(item, nameof(item));

            var oldItem = items.Find((Item arg) => arg.Id == item.Id);
            items.Remove(oldItem);
            items.Add(item);

            return await Task.FromResult(true);
        }
    }
}