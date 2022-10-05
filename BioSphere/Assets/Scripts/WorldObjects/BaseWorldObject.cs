using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseWorldObject : ScriptableObject
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private string parent;
    [SerializeField]
    private string layer;


    public void Awake()
    {
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not set for " + this);
        }
        if (parent == null)
        {
            Debug.LogWarning("Parent not set for " + this);
        }
    }

    public GameObject InstantiateWorldObject(Vector3 worldPos)
    {
        GameObject obj = Instantiate(prefab, worldPos, Quaternion.identity, GameObject.Find(parent).transform);

        if (layer != null)
        {
            obj.layer = LayerMask.NameToLayer(layer);
        }

        return obj;
    }
}