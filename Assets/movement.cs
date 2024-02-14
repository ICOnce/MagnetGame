using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("s")) GetComponent<Rigidbody>().AddForce(new Vector3(0,0,-1)*0.09f, ForceMode.VelocityChange);
        if (Input.GetKey("w")) GetComponent<Rigidbody>().AddForce(new Vector3(0,0,1)*0.09f, ForceMode.VelocityChange);
        if (Input.GetKey("d")) GetComponent<Rigidbody>().AddForce(new Vector3(1, 0, 0)*0.09f, ForceMode.VelocityChange);
        if (Input.GetKey("a")) GetComponent<Rigidbody>().AddForce(new Vector3(-1, 0, 0)*0.09f, ForceMode.VelocityChange);
    }
}
