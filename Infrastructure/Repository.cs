public class Repository<T> where T : class, IEntity
{
    private readonly Dictionary<string, T> _items = new();

    public void Add(T item)
    {
        if (_items.ContainsKey(item.Id))
        {
            throw new InvalidOperationException("An item with this ID already exists.");
        }

        _items.Add(item.Id, item);
    }

    public T GetById(string id)
    {
        if (!_items.ContainsKey(id))
        {
            throw new KeyNotFoundException("Item not found.");
        }

        return _items[id];
    }

    public bool Remove(string id)
    {
        return _items.Remove(id);
    }

    public IReadOnlyCollection<T> GetAll()
    {
        return _items.Values.ToList().AsReadOnly();
    }
}