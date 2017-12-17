using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    public LightGun lightGun;
    public float walkSpeed;
    public float jumpHeight;

    public Vector2 rotation;

    new private Rigidbody rigidbody;
    new private Camera camera;

    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        camera = gameObject.GetComponentInChildren<Camera>();//Camera.main;
    }

    void Update()
    {
        rotation.x += Input.GetAxis("Mouse X");
        rotation.y += Input.GetAxis("Mouse Y");
        rotation.y = Mathf.Clamp(rotation.y, -90, 90);

        transform.rotation = Quaternion.AngleAxis(rotation.x, Vector3.up);
        camera.transform.localRotation = Quaternion.Euler(-rotation.y, 0, 0);
       
        rigidbody.AddForce(Quaternion.AngleAxis(rotation.x, Vector3.up) * new Vector3(Input.GetAxis("Horizontal") * walkSpeed,0,walkSpeed * Input.GetAxis("Vertical")), ForceMode.Acceleration);
        if (Input.GetKeyDown("escape"))
        {
            Debug.Break();
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
