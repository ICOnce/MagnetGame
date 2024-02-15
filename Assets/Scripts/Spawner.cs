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
            curSquare = Instantiate(GreenSquare, new Vector3(-15, 16, 0), Quaternion.identity);
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
        GameObject[] NorthGravMag = GameObject.FindGameObjectsWithTag("North");
        GameObject[] SouthGravMag = GameObject.FindGameObjectsWithTag("South");
        GameObject[] squares = GameObject.FindGameObjectsWithTag("Tile");
        foreach (GameObject square in squares)
        {
            square.GetComponent<Rigidbody>().useGravity = true;
        }
        foreach(GameObject NGM in NorthGravMag)
        {
            NGM.GetComponent<Rigidbody>().useGravity = true;
        }
        foreach(GameObject SGM in SouthGravMag)
        {
            SGM.GetComponent<Rigidbody>().useGravity = true;
        }
    }

    public static bool gravity()
    {
        switch (useGrav)
        {
            case true: return true;
            case false: return false;
        }
    }
}
