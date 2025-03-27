using SimpleApi.Models;

namespace SimpleApi.Services
{
    public interface IItemService
    {
        List<Item> GetAll();
        Item? GetById(int id);
        Item Create(Item newItem);
        bool Update(int id, Item updatedItem);
        bool Delete(int id);
    }
}
