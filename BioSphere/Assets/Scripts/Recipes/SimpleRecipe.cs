using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RecipeType
{
    SimpleRecipe,
    RemainderRecipe
}

public enum RecipeStation
{
    PlayerInventory,
    Campfire
}

[CreateAssetMenu(fileName = "SimpleRecipe", menuName = "Item/Recipes")]
public class SimpleRecipe : ScriptableObject
{
    [SerializeField]
    private RecipeStation recipeStation;
    public RecipeStation GetStation()
    {
        return recipeStation;
    }

    [SerializeField]
    private Dictionary<BaseItem, int> input = new Dictionary<BaseItem,int>();
    public Dictionary<BaseItem, int> GetInput()
    {
        return input;
    }

    [SerializeField]
    private Dictionary<BaseItem, int> output = new Dictionary<BaseItem, int>();
    public Dictionary<BaseItem, int> GetOutput()
    {
        return output;
    }

    private RecipeType recipeType = RecipeType.SimpleRecipe;
    public RecipeType GetType()
    {
        return recipeType;
    }

    public bool IsViable(SimpleInventory inventory)
    {
        bool hasInputs = true;
        bool hasSpace = false;

        foreach (var pair in input)
        {
            if (inventory.GetItem(pair.Key) < pair.Value)
            {
                hasInputs = false;
            }
        }


        int slotsNeeded = output.Count;
        foreach (var pair in output)
        {
            if (inventory.GetItem(pair.Key) > 0)
            {
                slotsNeeded += -1;
            }
        }

        if (inventory.GetEmpties() >= slotsNeeded)
        {
            hasSpace = true;
        }

        if(hasInputs && hasSpace)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void Craft(SimpleInventory inventory)
    {
        foreach (var pair in input)
        {
            int remaining = pair.Value;
            int slotNumber;

            for (int x = 0; x > input.Count; x++)
            {
                while (remaining > 0)
                {
                    slotNumber = inventory.FindItem(pair.Key);
                    if (inventory.GetSlot(slotNumber).GetCount() < remaining)
                    {
                        remaining -= inventory.GetSlot(slotNumber).RemoveAll();
                    }
                    else
                    {
                        remaining = 0;
                        inventory.GetSlot(slotNumber).AddCount(-remaining);
                    }
                }
            }
        }

        foreach (var pair in output)
        {
            inventory.AddItem(pair.Key, pair.Value);
        }
    }


}
