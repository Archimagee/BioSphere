using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerInventory : BaseInventory
{
    protected override InventorySlot[] inventoryArray { get; } = new InventorySlot[15];

    private void Awake()
    {
        SetInventoryType(InventoryType.PlayerInventory);
    }

    private void Start()
    {

        for (int x = 0; x < inventoryArray.Length; x++)
        {
            imageObjectArray[x] = new InventorySlot();
        }
    }
}