using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;
    Rigidbody rigidbody;
    public float speed = 10.0f;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(player);
        rigidbody.velocity = transform.forward * speed;
    }
}
