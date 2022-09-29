using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InventoryType
{
    SimpleInventory
}

public class SimpleInventory : MonoBehaviour
{
    public BaseItem testItem;

    [SerializeField]
    private int columns;
    [SerializeField]
    private Vector3 baseOffset;
    [SerializeField]
    private float columnOffset;
    [SerializeField]
    private float rowOffset;

    [SerializeField]
    private List<SimpleInventorySlot> inventoryList = new List<SimpleInventorySlot>();

    [SerializeField]
    private GameObject slotParent;
    [SerializeField]
    private GameObject emptyPrefab;
    [SerializeField]
    private Canvas canvas;

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

    public void Awake()
    {
        for (int x = 0; x < size; x++)
        {
            inventoryList.Add(new SimpleInventorySlot());
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
        for (int x = 0; x < size; x++)
        {
            if (!inventoryList[x].IsEmpty())
            {
                Vector3 pos = new Vector3();
                pos.y = (Mathf.Ceil(x / columns)) * rowOffset;
                pos.x = (x % columns) * columnOffset;
                inventoryList[x].InstantiateItem(slotParent, pos);
            }
        }
    }

    public void RefreshSlot(int slot)
    {

    }

    public void ToggleInventory()
    {
        if(canvas.enabled)
        {
            canvas.enabled = false;
        }
        else
        {
            canvas.enabled = true;
            RefreshDisplay();
        }
    }
}
