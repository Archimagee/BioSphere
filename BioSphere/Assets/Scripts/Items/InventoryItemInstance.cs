using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItemInstance : ItemInstance
{


    public InventoryItemInstance(BaseItem _item, int _count)
    {
        myItem = _item;
        myCount = _count;
    }


    public void AddCount(int _count)
    {
        myCount += _count;
    }


}
