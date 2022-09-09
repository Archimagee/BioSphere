using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "FoodItem", menuName = "Item/FoodItem")]

public class FoodItem : BaseItem
{


    [SerializeField] private int hungerRestoreValue;
    public int GetHungerRestoreValue()
    {
        return hungerRestoreValue;
    }


    [SerializeField] private int healthRestoreValue;
    public int GetHealthRestoreValue()
    {
        return healthRestoreValue;
    }


    private void Awake()
    {
        SetCategory(ItemCategory.FoodItem);
    }


}
