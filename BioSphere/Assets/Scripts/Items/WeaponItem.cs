using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponItem", menuName = "Item/WeaponItem")]

public class WeaponItem : BaseItem
{


    [SerializeField] private int baseDurability;
    public int GetBaseDurability()
    {
        return baseDurability;
    }


    [SerializeField] private int baseDamage;
    public int GetBaseDamage()
    {
        return baseDamage;
    }


    private void Awake()
    {
        SetCategory(ItemCategory.WeaponItem);
    }


}
