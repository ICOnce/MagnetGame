using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private float speed = 30f;
    Rigidbody rb;
    

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey("s")) rb.AddForce(new Vector3(0, 0, -1) * speed * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKey("w")) rb.AddForce(new Vector3(0, 0, 1) * speed * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKey("d")) rb.AddForce(new Vector3(1, 0, 0) * speed * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKey("a")) rb.AddForce(new Vector3(-1, 0, 0) * speed * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetKey(KeyCode.UpArrow)) rb.AddForce(new Vector3(0, 1, 0) * speed * Time.deltaTime, ForceMode.Impulse);
        if (Input.GetKey(KeyCode.DownArrow)) rb.AddForce(new Vector3(0, -1, 0) * speed * Time.deltaTime, ForceMode.Impulse);

        if (!(Input.GetKey("s") || Input.GetKey("w") || Input.GetKey("d") || Input.GetKey("a")) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
        {
            rb.velocity = Vector3.zero;
        }
    }
}
