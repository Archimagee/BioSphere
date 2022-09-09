using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldItemInstance : ItemInstance
{


    public void SetItem(BaseItem _item)
    {
        myItem = _item;
    }


    public void SetCount(int _count)
    {
        myCount = _count;
    }


    public void OnTriggerEnter2D(Collider2D collider)
    {
        ItemPickuper pickuper = collider.gameObject.GetComponent<ItemPickuper>();

        if (pickuper != null)
        {
            pickuper.GetDestinationInventory().AddItem(GetItem(), GetCount());
            Destroy(this.gameObject);
        }

    }


}
