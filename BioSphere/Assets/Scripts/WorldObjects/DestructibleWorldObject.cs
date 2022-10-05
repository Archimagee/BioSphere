using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "DestructibleWorldObject", menuName = "WorldObjects/DestructibleWorldObject")]

public class DestructibleWorldObject : BaseWorldObject
{
    [SerializeField]
    private List<PercentageCountItem> droppedItems = new List<PercentageCountItem>();

    public List<CountItem> RollDrops()
    {
        List<CountItem> drops = new List<CountItem>();

        foreach (PercentageCountItem item in droppedItems)
        {
            int roll = Random.Range(1, 100);

            if (roll <= item.GetChance())
            {
                drops.Add(new CountItem(item.GetItem(), item.GetCount()));
            }
        }

        return drops;
    }


    [SerializeField]
    private int hitPoints;

    [SerializeField]
    private int requiredTier;

    [SerializeField]
    private ToolType requiredToolType;


    public void hit(int toolTier, ToolType toolType)
    {
        if (toolTier >= requiredTier || requiredToolType == toolType)
        {
            if (hitPoints <= 1)
            {
                DropItems();
                Destroy(this);
            }
            else
            {
                hitPoints += -1;
            }
        }


    }


    private void DropItems()
    {
        List<CountItem> drops = RollDrops();
    }
}
