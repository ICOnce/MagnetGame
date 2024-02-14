using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject GreenSquare;
    bool activeSquare;
    GameObject curSquare;
    static bool useGrav;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && activeSquare == false) 
        {
            useGrav = false;
            curSquare = Instantiate(GreenSquare, new Vector3(0, 1, 0), Quaternion.identity);
            curSquare.GetComponent<Rigidbody>().useGravity = false;
            activeSquare = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && activeSquare == true)
        {
            curSquare.GetComponent<movement>().enabled = false;
            //curSquare.GetComponent<Rigidbody>().useGravity = true;
            activeSquare = false;
        }
        if (Input.GetKey(KeyCode.Backspace))
        {
            useGrav = true;
            EnableGravity();
        }
    }

    private void EnableGravity()
    {
        GameObject[] squares = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject square in squares)
        {
            square.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public static bool gravity()
    {
        if (useGrav == true) return true;
        else return false;
    }
}
