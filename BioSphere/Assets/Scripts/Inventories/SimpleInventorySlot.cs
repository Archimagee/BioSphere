using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleInventorySlot
{
    private BaseItem item;
    public BaseItem GetItem()
    {
        return item;
    }
    public void SetItem(BaseItem _item)
    {
        item = _item;
    }

    private int count;
    public int GetCount()
    {
        return count;
    }
    public void AddCount(int _count)
    {
        count += _count;
    }
    public void SetCount(int _count)
    {
        count = _count;
    }


    public bool IsEmpty()
    {
        if (item != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public int RemoveAll()
    {
        // returns the number of items removed
        int removed = count;

        item = null;
        SetCount(0);

        return removed;
    }
}
