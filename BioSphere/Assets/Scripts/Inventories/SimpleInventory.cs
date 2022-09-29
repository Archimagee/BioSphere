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
    private InventoryType inventoryType = InventoryType.SimpleInventory;

    public SimpleInventorySlot GetSlot(int slot)
    {
        return inventoryList[slot];
    }

    public int GetMaxSize()
    {
        return size;
    }

    public InventoryType GetType()
    {
        return inventoryType;
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
}
