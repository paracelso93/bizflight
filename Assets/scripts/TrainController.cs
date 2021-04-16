using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour
{
    Rigidbody rigidbody;
    public float trainSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * trainSpeed;
        Debug.Log("force added!");
    }

    // Update is called once per frame
    void Update()
    {
        rigidbody.velocity = transform.forward * trainSpeed;
    }
}
