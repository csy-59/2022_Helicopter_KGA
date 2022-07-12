using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterInput : MonoBehaviour
{
    public bool IsStared { get; private set; }
    public bool F { get; private set; }

    public float X { get; private set; }
    public float Y { get; private set;}
    public float Z { get; private set; }

    // Update is called once per frame
    void Update()
    {
        F = false;
        X = Y = Z = 0f;

        if (Input.GetKeyDown(KeyCode.R))
            IsStared = !IsStared;
        F = Input.GetKeyDown(KeyCode.F);

        X = Input.GetAxis("Horizontal");
        Z = Input.GetAxis("Vertical");

        if(Input.GetKey(KeyCode.Q))
            Y = 1;
        else if(Input.GetKey(KeyCode.E))
            Y = -1;
    }
}
