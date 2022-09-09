using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SawmillRecipe", menuName = "Recipe/SawmillRecipe")]

public class SawmillRecipe : BaseRecipe
{

    private void Awake()
    {
        SetStation(RecipeStation.Sawmill);
    }

}
