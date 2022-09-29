using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldObjectPlacer : MonoBehaviour
{
    [SerializeField]
    private SimpleWorldObject obj;

    void Start()
    {
        obj.InstantiateWorldObject(new Vector3(0, 0, 0), "World Objects");
    }
}
