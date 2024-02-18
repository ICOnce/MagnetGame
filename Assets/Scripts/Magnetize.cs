using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Magnetize : MonoBehaviour
{
    private float pullStrength = 1f;
    List<Transform> magnets = new List<Transform>();
    [SerializeField] private Rigidbody parent;
    bool test = false;

    [SerializeField] private GameObject good, bad;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (test == false)
        {
            foreach (Transform magnet in magnets)
            {
                if (Vector3.Distance(magnet.position, transform.position) > 0.5f)
                {
                    magnets.Remove(magnet);
                    break;
                }
                if (magnet.tag == "North" && gameObject.tag == "South")
                {
                    parent.AddForceAtPosition(((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position), transform.position);
                    //parent.AddForce(((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position));
                    //magnet.AddForce(((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position) * Time.deltaTime);
                }
                else if (magnet.tag == "South" && gameObject.tag == "North")
                {
                    parent.AddForceAtPosition(((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position), transform.position);
                    //parent.AddForce(((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position));
                    //magnet.AddForce(((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position) * Time.deltaTime);
                }
                else
                {
                    parent.AddForceAtPosition(-((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position), transform.position);
                    //parent.AddForce(-((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position));
                    //magnet.AddForce(-((magnet.position - transform.position).normalized) * pullStrength / Vector3.Distance(magnet.position, transform.position) * Time.deltaTime);
                }
            }
        }
        else
        {
            bool triggered = false;
            foreach (Transform magnet in magnets)
            {
                triggered = false;
                if (triggered == false)
                {
                    if (Vector3.Distance(magnet.position, transform.position) > 1f)
                    {
                        magnets.Remove(magnet);
                        break;
                    }
                    if (magnet.tag == "North" && gameObject.tag == "South")
                    {
                        Instantiate(good, magnet.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
                        triggered = true;
                    }
                    else if (magnet.tag == "South" && gameObject.tag == "North")
                    {
                        Instantiate(good, magnet.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
                        triggered = true;
                    }
                    else
                    {
                        Instantiate(bad, magnet.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
                        triggered = true;
                    }
                }

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
