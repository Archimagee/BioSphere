using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum ToolType
{
    UniversalTool,
    PickaxeTool,
    AxeTool,
    ShovelTool
}


[CreateAssetMenu(fileName = "ToolItem", menuName = "Item/ToolItem")]

public class ToolItem : BaseItem
{
    [SerializeField]
    private float toolRange;

    [SerializeField]
    private int toolTier;

    [SerializeField]
    private ToolType toolType;
    public ToolType GetToolType()
    {
        return toolType;
    }

    new public void Awake()
    {
        SetCategory(ItemCategory.ToolItem);
    }

    override public void Use(Vector3 pos, Vector3 playerPos)
    {

    }
}
