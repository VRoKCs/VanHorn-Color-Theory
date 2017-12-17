using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beam : MonoBehaviour
{

    public Color color;
    public float intensity = 1;
    new private Rigidbody rigidbody;
    new public Light light;


    // Use this for initialization
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        Destroy(gameObject, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.LookRotation(rigidbody.velocity
        gameObject.GetComponent<Renderer>().material.color = color;
        light.color = color;
        gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
        gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", color);


        if (intensity <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //color -= collision.gameObject.GetComponent<Renderer>().material.color;
        Color colorC = collision.gameObject.GetComponent<Renderer>().material.color;
        float a = 0;
        float b = 0;
        float c = 0;

        float d = 0;
        float e = 0;
        float f = 0;

        Color.RGBToHSV(color, out a, out b, out c);
        Color.RGBToHSV(colorC, out d, out e, out f);

        Debug.Log(a + ", " + b + ", " + c + ", " + d + ", " + e + ", " + f);
        Debug.Log(0.54f - 0f);
        float difference = 0; //= ((color.r - colorC.r) + (color.g - colorC.g) + (color.b - colorC.b)) / 3f; //Mathf.Sqrt(Mathf.Pow(colorC.r - color.r, 2f) + Mathf.Pow(colorC.b - color.b, 2f) + Mathf.Pow(colorC.g - color.g, 2f));
        //Debug.Log("AAAH: " + difference);

        float diffA = Mathf.Abs(d - a);
        Debug.Log(diffA);
        float diffB = Mathf.Abs(1f - a) + d;
        float diffC = Mathf.Abs(1f - d) + a;

        if (diffA < diffB && diffA < diffC)
        {
            difference = diffA;
        }
        else if (diffB < diffA && diffB < diffC)
        {
            difference = diffB;
        }
        else if (diffC < diffA && diffC < diffB)
        {
            difference = diffC;
        }
        else
        {
            //Debug.LogError("If statements went wrong");
            Debug.LogWarning("A: " + diffA + " B: " + diffB + " C: " + diffC);
            difference = Mathf.Min(diffA, diffB, diffC);
        }

        difference *= 2;
        Debug.Log(difference);
        //a += 0.5f;

        if (c > f)
        {
            difference += (c - f);
            Debug.Log("Subtracting Lightness");
        }

        //color = Color.HSVToRGB(a, b, c);

        if (collision.gameObject.GetComponent<LightReciever>())
        {
            collision.gameObject.GetComponent<LightReciever>().Recieve(difference * intensity);
        }

        intensity -= difference;
        light.intensity = intensity;
        color = new Color(colorC.r, colorC.g, colorC.b, intensity);

        Debug.Log(color);


    }

}
