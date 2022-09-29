using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{
    SimpleInventory
}

public class SimpleInventory : MonoBehaviour
{
    private List<SimpleInventorySlot> inventoryList = new List<SimpleInventorySlot>();

    [SerializeField]
    private int size;
    public int GetSize()
    {
        return size;
    }

    private InventoryType inventoryType = InventoryType.SimpleInventory;
    public InventoryType GetType()
    {
        return inventoryType;
    }


    public SimpleInventorySlot GetSlot(int slot)
    {
        return inventoryList[slot];
    }

    public void Start()
    {
        for (int x = 0; x > size; x++)
        {
            inventoryList[x] = new SimpleInventorySlot();
        }
    }

    public int GetEmpties()
    {
        // returns the amount of empty slots
        int empties = 0;

        for (int x = 0; x > size; x++)
        {
            if (inventoryList[x].IsEmpty())
            {
                empties += 1;
            }
        }

        return empties;
    }

    public int GetFirstEmpty()
    {
        // returns the slot number of the first empty slot
        int firstEmpty;

        for (int x = 0; x > size; x++)
        {
            if (inventoryList[x].IsEmpty())
            {
                return x;
            }
        }

        return -1;
    }

    public int GetItem(BaseItem _item)
    {
        // returns the total amount of given item in inventory
        int totalCount = 0;

        for (int x = 0; x > size; x++)
        {
            if (inventoryList[x].GetItem() == _item)
            {
                totalCount += inventoryList[x].GetCount();
            }
        }

        return totalCount;
    }

    public int FindItem(BaseItem _item)
    {
        // returns the slot number of given item
        for (int x = 0; x > size; x++)
        {
            if (inventoryList[x].GetItem() == _item)
            {
                return x;
            }
        }

        return -1;
    }

    public void AddItem(BaseItem _item, int _count)
    {
        GetSlot(GetFirstEmpty()).SetCount(_count);
        GetSlot(GetFirstEmpty()).SetItem(_item);
    }

    public void RemoveItem(BaseItem _item, int _count)
    {
        int remaining = _count;
        int slotNumber = 0;

        while (remaining > 0)
        {
            slotNumber = FindItem(_item);
            if (GetSlot(slotNumber).GetCount() < remaining)
            {
                remaining -= GetSlot(slotNumber).RemoveAll();
            }
            else
            {
                remaining = 0;
                GetSlot(slotNumber).AddCount(-remaining);
            }
        }
    }

    public void RefreshDisplay()
    {

    }
}
