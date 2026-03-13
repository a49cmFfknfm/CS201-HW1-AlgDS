namespace AlgSD_HW1;

public class СStack
{
    private double[] _items;
    private int _top = -1;

    public СStack()
    {
        _items = new double[4];
    }

    public void Push(double val)
    {
        if (_top == _items.Length - 1)
        {
            Resize();
        }
        
        var n = _top + 1;
        _items[n] = val;
    }

    public double Pop()
    {
        if (IsEmpty()) throw new Exception("Stack is empty");
        return _items[_top--];
    }

    public double Peek()
    {
        if (IsEmpty()) throw new Exception("Stack is empty");
        return _items[_top];
    }

    public bool IsEmpty() => _top == -1;

    private void Resize()
    {
        double[] nueva = new double[_items.Length*2];
        for (int i=0; i <= _top; i++)
        {
            nueva[i] = _items[i];
        }
        _items = nueva;
    }
}