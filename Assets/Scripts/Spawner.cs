using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject GreenSquare;
    bool activeSquare;
    GameObject curSquare;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activeSquare == false) 
        {
            curSquare = Instantiate(GreenSquare, new Vector3(0, 1, 0), Quaternion.identity);
            curSquare.GetComponent<Rigidbody>().useGravity = false;
            activeSquare = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && activeSquare == true)
        {
            curSquare.GetComponent<movement>().enabled = false;
            curSquare.GetComponent<Rigidbody>().useGravity = true;
            activeSquare = false;
        }
    }
}
