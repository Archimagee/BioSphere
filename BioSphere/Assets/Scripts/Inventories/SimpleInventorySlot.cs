using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class SimpleInventorySlot
{
    private GameObject obj;
    public GameObject GetObj()
    {
        return obj;
    }

    private Sprite objImage;
    public Sprite GetObjImage()
    {
        return objImage;
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

    private BaseItem displayedItem;
    public BaseItem GetDisplayedItem()
    {
        return displayedItem;
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

    private GameObject emptyPrefab;
    public void SetEmptyPrefab(GameObject _emptyPrefab)
    {
        emptyPrefab = _emptyPrefab;
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


    public void RefreshSlot(GameObject slotParent, Vector3 pos)
    {
        if (displayedItem != null)
        {
            UnityEngine.Object.Destroy(obj);
        }

        if (item != null)
        {
            obj = Object.Instantiate(emptyPrefab, pos, Quaternion.identity, slotParent.transform);

            if (GetItem().GetImage() != null)
            {
                objImage = GetItem().GetImage();
                obj.GetComponent<Image>().sprite = GetItem().GetImage();
            }

            displayedItem = item;
        }
        else
        {
            displayedItem = null;
        }

        RefreshCount();
    }


    public void RefreshCount()
    {
        obj.GetComponentInChildren<TextMeshProUGUI>().text = count.ToString();
    }


    public int RemoveAll()
    {
        // returns the number of items removed
        int removed = count;

        item = null;
        displayedItem = null;
        UnityEngine.Object.Destroy(obj);
        SetCount(0);

        return removed;
    }
}
