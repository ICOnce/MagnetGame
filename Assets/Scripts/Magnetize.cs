using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnetize : MonoBehaviour
{
    private float pullStrength = 100f;
    List<Transform> magnets = new List<Transform>();
    [SerializeField] private Rigidbody parent;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        foreach (Transform magnet in magnets) 
        {
            if (Vector3.Distance(magnet.position, transform.position) > 1f) 
            {
                magnets.Remove(magnet);
                break;
            }
            if (magnet.tag == "North" && gameObject.tag == "South")
            {
                parent.AddForce(((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position) * Time.deltaTime);
            }
            else if (magnet.tag == "South" && gameObject.tag == "North")
            {
                parent.AddForce(((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position) * Time.deltaTime);
            }
            else
            {
                parent.AddForce(-((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position) * Time.deltaTime);
            }
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "North" || other.tag == "South")
        {
            magnets.Add(other.GetComponent<Transform>());
        }

    }
}
