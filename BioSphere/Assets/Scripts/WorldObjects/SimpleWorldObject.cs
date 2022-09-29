using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "SimpleWorldObject", menuName = "WorldObjects/SimpleWorldObject")]
public class SimpleWorldObject : ScriptableObject
{
    [SerializeField]
    private List<PercentageCountItem> droppedItems = new List<PercentageCountItem>();

    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    private string parent;


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

    public GameObject InstantiateWorldObject(Vector3 worldPos, string layer)
    {
        GameObject obj = Instantiate(prefab, worldPos, Quaternion.identity, GameObject.Find(parent).transform);

        obj.layer = LayerMask.NameToLayer(layer);

        return obj;
    }
}