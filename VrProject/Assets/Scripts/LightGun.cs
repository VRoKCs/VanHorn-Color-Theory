using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightGun : MonoBehaviour {

    public float charge;
    public float fireDelay;
    public GameObject beam;
    public Color color;
    public Vector3 offset;
    public static float speedOfLight = 15;
    public int colorIndex;

    public Color[] colors;

	// Use this for initialization
	void Start ()
    {
        //Shoot();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if (Input.GetButtonDown("Fire2"))
        {
            if (colorIndex >= colors.Length - 1)
            {
                colorIndex = 0;
            }
            else
            {
                colorIndex += 1;
            }

            color = colors[colorIndex];
        }
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    public void Shoot()
    {
        GameObject temp = Instantiate(beam, transform.position,new Quaternion());
        Rigidbody rigid = temp.GetComponent<Rigidbody>();
        rigid.AddForce(transform.rotation * new Vector3(0,0,10),ForceMode.VelocityChange);
        temp.GetComponent<Beam>().color = color;
        Destroy(temp, 10f);
    }
}
