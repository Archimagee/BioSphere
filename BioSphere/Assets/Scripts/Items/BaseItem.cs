using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ItemCategory
{
    SimpleItem,
    WeaponItem,
    ToolItem,
    ArmourItem,
    FoodItem,
    PlaceableItem
}



public abstract class BaseItem : ScriptableObject
{
    private ItemCategory category;
    protected void SetCategory(ItemCategory _category)
    {
        category = _category;
    }
    public ItemCategory GetCategory()
    {
        return category;
    }

    [SerializeField]
    private Sprite itemImage;
    public Sprite GetImage()
    {
        return itemImage;
    }

    [SerializeField]
    private int stackSize;
    public int GetStackSize()
    {
        return stackSize;
    }


    [SerializeField] private int itemID;
    public int GetItemID()
    {
        return itemID;
    }


    [SerializeField] private string description;
    public string GetDescription()
    {
        return description;
    }

    [SerializeField] private new string name;
    public string GetName()
    {
        return name;
    }



    public void Awake()
    {
        if (stackSize == 0)
        {
            Debug.LogWarning("Stack size is 0 for " + this);
        }

        if (itemImage == null)
        {
            Debug.LogWarning("Image not set for " + this);
        }
    }


    abstract public void Use(Vector3 pos, Vector3 playerPos);
}
