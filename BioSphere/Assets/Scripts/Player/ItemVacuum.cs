using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemVacuum : MonoBehaviour
{


    [SerializeField] private float vacuumRadius;
    [SerializeField] private float strength;
    private int layerMask;


    void Start()
    {
        layerMask = LayerMask.NameToLayer("WorldItemLayer");
    }


    void Update()
    {


        Collider2D[] collidersHit = Physics2D.OverlapCircleAll(this.transform.position, vacuumRadius, ~layerMask);

        for (int x = 0; x < collidersHit.Length; x++)
        {

            Vector2 directionToPlayer = -(collidersHit[x].gameObject.transform.position - this.transform.position);
            directionToPlayer.Normalize();
            collidersHit[x].gameObject.transform.position += new Vector3(directionToPlayer.x, directionToPlayer.y, 0) * strength/50;

        }
    }
}
