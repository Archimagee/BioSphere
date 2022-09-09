using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum RecipeStation
{
    Sawmill,
    Furnace
}

public class BaseRecipe : ScriptableObject
{

    private RecipeStation station;
    protected void SetStation(RecipeStation _station)
    {
        station = _station;
    }
    public RecipeStation GetStation()
    {
        return station;
    }

    [SerializeField] private int recipeID;
    public int GetRecipeID()
    {
        return recipeID;
    }

}
