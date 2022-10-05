using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHotbarInventory : SimpleInventory
{
    private int selectedSlot = 1;

    [SerializeField]
    private GameObject hotbarPointer;

    [SerializeField]
    private Vector3 pointerBasePos;

    [SerializeField]
    private KeyCode useKey;

    override public void Awake()
    {
        inventoryType = InventoryType.PlayerHotbarInventory;

        if (slotParent == null)
        {
            Debug.LogWarning("slotParent not assigned to " + this + "\n Assigning to self");
            slotParent = this.gameObject;
        }

        for (int x = 0; x < size; x++)
        {
            SimpleInventorySlot newSlot = new SimpleInventorySlot();
            inventoryList.Add(newSlot);
            newSlot.SetEmptyPrefab(emptyPrefab);
            Debug.Log("Initialised inventory " + this + " with " + size + " slots");
        }
    }


    public void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") != 0f)
        {
            selectedSlot += -Mathf.CeilToInt(Input.GetAxis("Mouse ScrollWheel") * 10);

            if (selectedSlot < 1)
            {
                selectedSlot = size;
            }
            if (selectedSlot > size)
            {
                selectedSlot = 1;
            }

            Vector3 targetPos = new Vector3();
            targetPos = pointerBasePos;
            targetPos.x += selectedSlot * columnOffset;

            hotbarPointer.transform.position = targetPos;
        }


        if (Input.GetKeyDown(useKey))
        {
            if (inventoryList[selectedSlot - 1].GetItem() != null)
            {
                inventoryList[selectedSlot - 1].GetItem().Use(Camera.main.ScreenToWorldPoint(Input.mousePosition), this.gameObject.transform.position);
            }
        }
    }
}
