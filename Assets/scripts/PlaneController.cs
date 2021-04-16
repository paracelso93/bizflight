using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlaneController : MonoBehaviour
{
    public Slider slider;
    public float speed = 100.0f;
    public float rotation_speed = 10.0f;
    Rigidbody rigidbody;
    public float coolDown = 0.2f;
    float time;
    public GameObject projectile;
    public float projectileDestroyTime = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 0.0f;
        slider.maxValue = 40.0f;
        rigidbody = GetComponent<Rigidbody>();
        slider.value = speed;
        time = coolDown;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) {
            if (time <= 0.0f) {
                GameObject proj = Instantiate(projectile, transform.position + transform.forward * 15.0f, transform.rotation);
                proj.GetComponent<Transform>().Rotate(-90, 0, 0);
                proj.GetComponent<Rigidbody>().AddForce(transform.forward * 100);
                Destroy(proj, projectileDestroyTime);
                time = coolDown;
            }
        }
        time -= Time.deltaTime;
        float pitch = Input.GetAxis("Vertical") * rotation_speed * Time.deltaTime; // S W
        float roll = -Input.GetAxis("Roll") * rotation_speed * Time.deltaTime; // Q E
        float yaw = Input.GetAxis("Horizontal") * rotation_speed * Time.deltaTime; // A D
        if (Input.GetKey(KeyCode.LeftShift)) {
            speed += 0.5f;
            speed = Mathf.Clamp(speed, 0.0f, 40.0f);
            slider.value = speed;
        }
        if (Input.GetKey(KeyCode.LeftControl)) {
            speed -= 0.5f;
            speed = Mathf.Clamp(speed, 0.0f, 40.0f);
            slider.value = speed;
        }
        
        //transform.Rotate(pitch, yaw, roll, Space.World);
        //rigidbody.rotation = Quaternion.Euler(pitch * 100, yaw * 100, roll * 100);
        transform.Rotate(new Vector3(pitch, yaw, roll));
        rigidbody.velocity = transform.forward * speed;
    }
}
