using System.Collections;

namespace Lab7;

public class DNodesEnumerator : IEnumerator<DNode>
{
    private readonly DLinkedList _list;
    private int _position;

    public DNodesEnumerator(DLinkedList list)
    {
        _list = list;
        _position = -1;
    }

    public bool MoveNext()
    {
        if (_position < _list.Size - 1)
        {
            _position++;
            return true;
        }

        return false;
    }

    public void Reset()
    {
        _position = -1;
    }

    object IEnumerator.Current => Current;

    public DNode Current
    {
        get
        {
            if (_position == -1 || _position >= _list.Size)
            {
                throw new ArgumentException();
            }
                
            return _list[_position];
        }
    }
        
    public void Dispose()
    {
    }
}