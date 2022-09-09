using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public enum ItemCategory
{
    SimpleItem,
    WeaponItem,
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

    [SerializeField] private string name;
    public string GetName()
    {
        return name;
    }


    [SerializeField] private GameObject inventoryPrefab;
    public GameObject InstantiateInventoryItem(int _count, Transform _parent)
    {
        GameObject gameObject = Instantiate(inventoryPrefab, _parent);
        return gameObject;

    }


    [SerializeField] private GameObject worldPrefab;
    public GameObject InstantiateDroppedItem(int _count, Vector3 _position)
    {
        GameObject gameObject = Instantiate(worldPrefab, _position, Quaternion.identity);
        return gameObject;
    }




    public void StartDrag()
    {

    }


}
