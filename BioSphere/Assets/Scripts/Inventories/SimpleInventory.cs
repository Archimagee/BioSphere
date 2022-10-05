using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{
    SimpleInventory,
    PlayerHotbarInventory
}

public class SimpleInventory : MonoBehaviour
{
    [SerializeField]
    protected int columns;
    [SerializeField]
    protected Vector3 basePos;
    [SerializeField]
    protected float columnOffset;
    [SerializeField]
    protected float rowOffset;

    [SerializeField]
    protected List<SimpleInventorySlot> inventoryList = new List<SimpleInventorySlot>();

    [SerializeField]
    protected GameObject slotParent;
    [SerializeField]
    protected GameObject emptyPrefab;

    [SerializeField]
    protected int size;
    public int GetSize()
    {
        return size;
    }

    protected InventoryType inventoryType = InventoryType.SimpleInventory;
    public InventoryType GetInventoryType()
    {
        return inventoryType;
    }


    public SimpleInventorySlot GetSlot(int slot)
    {
        return inventoryList[slot];
    }

    virtual public void Awake()
    {
        if (slotParent == null)
        {
            Debug.LogWarning("slotParent not assigned to " + this + "\n Assigning to self");
            slotParent = this.gameObject;
        }

        for (int x = 0; x < size; x++)
        {
            SimpleInventorySlot newSlot = new SimpleInventorySlot();
            inventoryList.Add(newSlot);
            newSlot.SetEmptyPrefab(emptyPrefab);
            Debug.Log("Initialised inventory " + this + " with " + size + " slots");
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
        int firstEmpty = GetFirstEmpty();
        GetSlot(firstEmpty).SetCount(_count);
        GetSlot(firstEmpty).SetItem(_item);
        RefreshSlot(firstEmpty);
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

    public Vector3 GetPos(int slot)
    {
        Vector3 pos = basePos;
        pos.y += (Mathf.Ceil(slot / columns)) * rowOffset;
        pos.x += (slot % columns) * columnOffset;
        return pos;
    }

    public void RefreshDisplay()
    {
        for (int x = 0; x < size; x++)
        {
            if (inventoryList[x].GetItem() != inventoryList[x].GetDisplayedItem())
            {
                inventoryList[x].RefreshSlot(slotParent, GetPos(x));
                inventoryList[x].RefreshCount();
            }
        }
    }

    public void RefreshSlot(int slot)
    {
        inventoryList[slot].RefreshSlot(slotParent, GetPos(slot));
    }
}
