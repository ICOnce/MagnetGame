using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Magnetize : MonoBehaviour
{
    // Start is called before the first frame update
    private float pullStrength = 10f;
    List<Rigidbody> magnets = new List<Rigidbody>();
    [SerializeField] private Rigidbody parent;

    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (Rigidbody magnet in magnets) 
        {
            if (Vector3.Distance(magnet.position, transform.position) > 1f) 
            {
                magnets.Remove(magnet);
                break;
            }
            Rigidbody temp = magnet.GetComponentInParent<Transform>().GetComponentInParent<Rigidbody>();
            parent.AddForce((magnet.position - transform.position) * pullStrength / Vector3.Distance(magnet.position, transform.position)*Time.deltaTime, ForceMode.VelocityChange);
            Debug.Log((magnet.position - transform.position) * pullStrength / Vector3.Distance(magnet.position, transform.position));
            Debug.Log(temp.name);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Magnet")
        {
            magnets.Add(other.GetComponent<Rigidbody>());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //magnets.Remove(other.GetComponent<Rigidbody>());
    }
}
