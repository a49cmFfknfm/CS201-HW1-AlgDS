namespace AlgSD_HW1;

public class TList
{
    private string[] _items;
    private int _count;

    public TList()
    {
        _count = -1;
        _items = new string[4];
    }

    public int Length()
    {
        return _count + 1;
    }
    
    public string Get(int index)
    {
        if (index < 0 || index > _count) 
        {
            throw new Exception("Index out of range!");
        }
        return _items[index];
    }
    
    public void Add(string x)
    {
        if ((_count+1) == _items.Length)
        {
            Resize();
        }

        _items[++_count] = x;

    }

    public void Print()
    {
        Console.Write("\n[ ");
        for (int i = 0; i <= _count; i++)
        {
            if (i == _count)
            {
                Console.Write($"{_items[i]}]");
            }
            else
            Console.Write($"{_items[i]}, ");
        }
    }
    private void Resize()
    {
        string[] nueva = new string[_items.Length * 2];
        for (int i = 0; i <= _count; i++)
        {
            nueva[i] = _items[i];
        }

        _items = nueva;
    }
}