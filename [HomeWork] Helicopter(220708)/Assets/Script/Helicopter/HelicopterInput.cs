using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterInput : MonoBehaviour
{
    public bool R { get; private set; }

    public float X { get; private set; }
    public float Y { get; private set;}

    // Update is called once per frame
    void Update()
    {
        R = false;
        X = Y = 0f;

        R = Input.GetKeyDown(KeyCode.R);
        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
    }
}
