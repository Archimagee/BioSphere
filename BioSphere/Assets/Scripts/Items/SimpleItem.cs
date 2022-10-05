using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SimpleItem", menuName = "Item/SimpleItem")]

public class SimpleItem : BaseItem
{

    new public void Awake()
    {
        SetCategory(ItemCategory.SimpleItem);
    }


    override public void Use(Vector3 pos, Vector3 playerPos)
    {

    }
}
