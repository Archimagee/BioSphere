using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickuper : MonoBehaviour
{


    [SerializeField] private BaseInventory destinationInventory;
    public BaseInventory GetDestinationInventory()
    {
        return destinationInventory;
    }


}
