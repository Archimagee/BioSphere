using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CountItem
{
    [SerializeField]
    private BaseItem item;
    public BaseItem GetItem()
    {
        return item;
    }

    [SerializeField]
    private int count;
    public int GetCount()
    {
        return count;
    }


    public CountItem(BaseItem _item, int _count)
    {
        // constructor
        item = _item;
        count = _count;
    }
}
