using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnetize : MonoBehaviour
{
    private float pullStrength = 100f;
    List<Rigidbody> magnets = new List<Rigidbody>();
    [SerializeField] private Rigidbody parent;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        foreach (Rigidbody magnet in magnets) 
        {
            if (Vector3.Distance(magnet.position, transform.position) > 1f) 
            {
                magnets.Remove(magnet);
                break;
            }
            parent.AddForce(((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position)*Time.deltaTime);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magnet")
        {
            magnets.Add(other.GetComponent<Rigidbody>());
        }

    }
}
