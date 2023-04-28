using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderDisabler : MonoBehaviour
{
    public LayerMask layersToDisable;
    private Collider2D[] colliders;

    void Start()
    {
        colliders = Physics2D.OverlapAreaAll(new Vector2(-1000, -1000), new Vector2(1000, 1000), layersToDisable.value);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            foreach (Collider2D collider in colliders)
            {
                collider.enabled = false;
            }
        }
        else
        {
            foreach (Collider2D collider in colliders)
            {
                collider.enabled = true;
            }
        }
    }
}
