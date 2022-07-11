using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterInput : MonoBehaviour
{
    public bool R { get; private set; }

    public float X { get; private set; }
    public float Y { get; private set;}
    public float Z { get; private set; }

    // Update is called once per frame
    void Update()
    {
        R = false;
        X = Y = Z = 0f;

        R = Input.GetKeyDown(KeyCode.R);
        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Q))
            Y = 1;
        else if(Input.GetKey(KeyCode.E))
            Y = -1;
    }
}
