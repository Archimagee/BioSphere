using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryOpener : MonoBehaviour
{
    [SerializeField]
    private Canvas targetCanvas;

    [SerializeField]
    private KeyCode inventoryToggleKey;


    public void Awake()
    {
        if (targetCanvas == null)
        {
            targetCanvas = this.GetComponent<Canvas>();
            if (targetCanvas == null)
            {
                Debug.LogWarning("Target canvas not assigned to " + this + "\n Could not find canvas to assign");
            }
            else
            {
                Debug.LogWarning("Target canvas not assigned to " + this + "\n Found canvas on self to assign");
            }
        }
    }


    public void Update()
    {
        if(Input.GetKeyDown(inventoryToggleKey))
        {
            if (targetCanvas.enabled)
            {
                targetCanvas.enabled = false;
            }
            else
            {
                targetCanvas.enabled = true;

                SimpleInventory[] inventories = this.GetComponents<SimpleInventory>();

                foreach (SimpleInventory inventory in inventories)
                {
                    inventory.RefreshDisplay();
                }
            }
        }
    }
}
