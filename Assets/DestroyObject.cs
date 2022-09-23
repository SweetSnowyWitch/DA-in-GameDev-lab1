using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour
{
    public float radius = 5.0f;
    public float force = 10.0f;
    public GameObject prefabBoomPoint;
    public GameObject prefabBoomSphere;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name.Equals("Sphere"))
        {
            Destroy(other.gameObject);
            var boomPosition = other.gameObject.transform.position;
            Instantiate(prefabBoomPoint, other.gameObject.transform.position, other.gameObject.transform.rotation);
            Instantiate(prefabBoomSphere, other.gameObject.transform.position, other.gameObject.transform.rotation);
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
    }
}
