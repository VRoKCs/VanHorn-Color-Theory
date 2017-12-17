using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : LightReciever
{
    public LayerMask mask;
    public int health;
    public float aggroRange;
    public float damage;
    public float speed;
    public GameObject goal;

    new private Rigidbody rigidbody;

    // Use this for initialization
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.Normalize(goal.transform.position - transform.position));
        RaycastHit hit;
        Physics.Raycast(ray, out hit, mask);
        if (hit.distance <= aggroRange && hit.collider.gameObject == goal)
        {
            rigidbody.AddForce((Vector3.Normalize(goal.transform.position - transform.position)) * speed);
        }
    }

    public override void Recieve(float absorbed)
    {
        //base.Recieve(absorbed);
        if (absorbed >= absorbedRequired)
        {
            health -= 1;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

}
