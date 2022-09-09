using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SimpleItem", menuName = "Item/SimpleItem")]

public class SimpleItem : BaseItem
{

    private void Awake()
    {
        SetCategory(ItemCategory.SimpleItem);
    }

}
