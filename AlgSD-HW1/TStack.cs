namespace AlgSD_HW1;

public class TStack
{
    private string[] _items;
    private int _top = -1;
    
    public TStack()
    {
        _items = new string[4];
    }
    
    public void Push(string token)
    {
        if (_top == _items.Length - 1)
        {
            Resize();
        }
        _items[++_top] = token;
    }
    
    public string Pop()
    {
        if (IsEmpty()) return null;
        return _items[_top--];
    }

    public string Peek()
    {
        if (IsEmpty()) return null;
        return _items[_top];
    }
    
    
    private void Resize()
    {
        string[] newArray = new string[_items.Length*2];
        for (int i = 0; i <= _top; i++)
        {
            newArray[i] = _items[i];
        }
        _items = newArray;
    }
    
    public bool IsEmpty() => _top == -1;
}