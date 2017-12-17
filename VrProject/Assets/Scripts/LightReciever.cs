using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightReciever : MonoBehaviour
{
    public float absorbedRequired;
    public UnityEvent onRecieveMax;
    public Color color;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<Renderer>().material.color = color;
    }

    public virtual void Recieve(float absorbed)
    {
        Debug.Log("Recieved " + absorbed);
        if (absorbed >= absorbedRequired)
        {
            onRecieveMax.Invoke();
            Debug.Log("Recieved max!");
        }
    }

}
