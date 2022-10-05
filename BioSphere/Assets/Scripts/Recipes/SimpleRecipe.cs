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

[CreateAssetMenu(fileName = "SimpleRecipe", menuName = "Recipes/SimpleRecipe")]
public class SimpleRecipe : ScriptableObject
{
    [SerializeField]
    private RecipeStation recipeStation;
    public RecipeStation GetStation()
    {
        return recipeStation;
    }

    [SerializeField]
    public List<CountItem> input = new List<CountItem>();
    public List<CountItem> GetInput()
    {
        return input;
    }

    [SerializeField]
    public List<CountItem> output = new List<CountItem>();
    public List<CountItem> GetOutput()
    {
        return output;
    }

    private RecipeType recipeType = RecipeType.SimpleRecipe;
    public RecipeType GetRecipeType()
    {
        return recipeType;
    }

    public bool IsViable(SimpleInventory inventory)
    {
        bool hasInputs = true;
        bool hasSpace = false;

        foreach (CountItem recipeItem in input)
        {
            if (inventory.GetItem(recipeItem.GetItem()) < recipeItem.GetCount())
            {
                hasInputs = false;
            }
        }


        int slotsNeeded = output.Count;
        foreach (CountItem recipeItem in output)
        {
            if (inventory.GetItem(recipeItem.GetItem()) > 0)
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
        foreach (CountItem recipeItem in input)
        {
            inventory.RemoveItem(recipeItem.GetItem(), recipeItem.GetCount());
        }

        foreach (CountItem recipeItem in output)
        {
            inventory.AddItem(recipeItem.GetItem(), recipeItem.GetCount());
        }

        inventory.RefreshDisplay();
    }

}
