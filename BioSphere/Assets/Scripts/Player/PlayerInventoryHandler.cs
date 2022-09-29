using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryHandler : MonoBehaviour
{
    [SerializeField]
    private SimpleInventory playerInventory;

    [SerializeField]
    private KeyCode inventoryToggleKey;

    public void Update()
    {
        if(Input.GetKeyDown(inventoryToggleKey))
        {
            playerInventory.ToggleInventory();
        }
    }
}
