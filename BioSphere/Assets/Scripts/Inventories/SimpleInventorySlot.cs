using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SimpleInventorySlot
{
    private GameObject obj;
    public GameObject GetObj()
    {
        return obj;
    }

    [SerializeField]
    private BaseItem item = null;
    public BaseItem GetItem()
    {
        return item;
    }
    public void SetItem(BaseItem _item)
    {
        item = _item;
    }

    [SerializeField]
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
        if (item == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void InstantiateItem(GameObject slotParent, Vector3 pos)
    {
        if (obj != null)
        {
            UnityEngine.Object.Destroy(obj);
        }

        GetItem().InstantiateInventoryItem(slotParent.transform, pos);
    }


    public int RemoveAll()
    {
        // returns the number of items removed
        int removed = count;

        item = null;
        UnityEngine.Object.Destroy(obj);
        SetCount(0);

        return removed;
    }
}
