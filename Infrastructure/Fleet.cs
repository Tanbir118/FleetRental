using System.Collections;
using System.Collections.Generic;

public class Fleet : IEnumerable<Vehicle>
{
    private readonly List<Vehicle> _vehicles = new();

    public IEnumerator<Vehicle> GetEnumerator()
    {
        foreach (var v in _vehicles)
        {
            yield return v;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}