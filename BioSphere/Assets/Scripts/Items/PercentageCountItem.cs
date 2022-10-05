using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PercentageCountItem : CountItem
{
    [SerializeField]
    private int chance;
    public int GetChance()
    {
        return chance;
    }

    public PercentageCountItem(BaseItem _item, int _count, int _chance) : base(_item, _count)
    {
        chance = _chance;
    }
}