using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointBoom : MonoBehaviour
{
    public float radius = 5.0f;
    public float force = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        var boomPosition = transform.position;
        var colliders = Physics.OverlapSphere(boomPosition, radius);
        foreach (var hit in colliders)
        {
            var rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(force, boomPosition, radius, 3.0f);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
