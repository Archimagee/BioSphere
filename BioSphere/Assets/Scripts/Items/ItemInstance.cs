using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInstance : MonoBehaviour
{


    [SerializeField] protected BaseItem myItem;
    [SerializeField] protected int myCount;


    public BaseItem GetItem()
    {
        return myItem;
    }


    public int GetCount()
    {
        return myCount;
    }


}
