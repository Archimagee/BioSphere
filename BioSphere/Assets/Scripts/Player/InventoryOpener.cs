using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    [SerializeField]
    private SimpleInventory targetInventory;

    [SerializeField]
    private KeyCode inventoryToggleKey;


    public void Awake()
    {
        if (targetInventory == null)
        {
            Debug.LogWarning("Target inventory not assigned to " + this);
        }
    }


    public void Update()
    {
        if(Input.GetKeyDown(inventoryToggleKey))
        {
            targetInventory.ToggleInventory();
        }
    }
}
