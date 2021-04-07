using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneController : MonoBehaviour
{

    public float speed = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float pitch = -Input.GetAxis("Vertical") * speed;
        float roll = Input.GetAxis("Horizontal") * speed;
        //Quaternion rotation = transform.rotation;
        //Vector3 euler = rotation.eulerAngles;
        transform.Rotate(pitch, 0, roll, Space.World);
        transform.Translate(transform.forward * Time.deltaTime * speed);
    }
}
