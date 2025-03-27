using System.Collections.Generic;
using System.Linq;
using SimpleApi.Models;

namespace SimpleApi.Services
{
    public class ItemService : IItemService
    {
        private readonly List<Item> _items = new List<Item>();

        public List<Item> GetAll() => _items;

        public Item? GetById(int id) => _items.FirstOrDefault(i => i.Id == id);

        public Item Create(Item newItem)
        {
            newItem.Id = _items.Count + 1;
            _items.Add(newItem);
            return newItem;
        }

        public bool Update(int id, Item updatedItem)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return false;

            item.Name = updatedItem.Name;
            return true;
        }

        public bool Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null) return false;

            _items.Remove(item);
            return true;
        }
    }
}
