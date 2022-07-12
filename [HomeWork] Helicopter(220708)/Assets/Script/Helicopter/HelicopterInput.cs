using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterInput : MonoBehaviour
{
    public bool IsStared { get; private set; }
    public bool Fire { get; private set; }

    public float X { get; private set; }
    public float Y { get; private set;}
    public float Z { get; private set; }

    // Update is called once per frame
    private void Update()
    {
        Fire = false;
        X = Y = Z = 0f;

        if (Input.GetKeyDown(KeyCode.R))
            IsStared = !IsStared;
        Fire = Input.GetKeyDown(KeyCode.F);

        X = Input.GetAxis("Horizontal");
        Y = Input.GetAxis("Vertical");
        Z = Input.GetAxis("Forward");
    }
}
