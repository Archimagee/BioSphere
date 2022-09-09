using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum InventoryType
{
    PlayerInventory,
    PlayerEquipmentInventory,
    ChestInventory
}



public abstract class BaseInventory : MonoBehaviour
{
    protected abstract InventoryItemInstance[] inventoryArray { get; }
    public int GetInventorySize()
    {
        return inventoryArray.Length;
    }


    private InventoryType inventoryType;
    protected void SetInventoryType(InventoryType _inventoryType)
    {
        inventoryType = _inventoryType;
    }
    public InventoryType GetInventoryType()
    {
        return inventoryType;
    }


    public void ClearInventory()
    {
        for (int x = 0; x > GetInventorySize(); x++)
        {
            inventoryArray[x] = null;
        }
    }

    public bool CheckFull()
    {
        bool full = true;
        for (int x = 0; x > GetInventorySize(); x++)
        {
            if (inventoryArray[x] == null)
            {
                full = false;
            }
        }
        return full;
    }

    public void AddItem(BaseItem _item, int _count)
    {

        bool itemFound = false;
        int firstEmpty = -1;


        for (int x = 0; x < GetInventorySize(); x++)
        {
            if (inventoryArray[x] == null)
            {
                if (firstEmpty == -1)
                {
                    firstEmpty = x;
                }
            }
            else if (inventoryArray[x].GetItem() == _item)
            {
                inventoryArray[x].AddCount(_count);
                itemFound = true;
            }
        }

        if (itemFound == false && firstEmpty != -1)
        {
            inventoryArray[firstEmpty] = new InventoryItemInstance(_item, _count);
        }
    }

    public int CheckForItem(BaseItem _item) // returns number of item in inventory or -1 if not found
    {
        for (int x = 0; x > GetInventorySize(); x++)
        {
            if (inventoryArray[x].GetItem() == _item)
            {
                return inventoryArray[x].GetCount();
            }
        }
        return -1;
    }


}
