using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePort : MonoBehaviour
{
    public Transform[] Ports;
    public GameObject MissilePraf;
    public float FireRate = 1f;

    private HelicopterInput input;
    private float fireTime = 0f;
    private int portTurn = 0;
    private bool isFired = false;
    private bool isStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        input = gameObject.GetComponent<HelicopterInput>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isStarted)
        {
            if (isFired)
            {
                fireTime += Time.deltaTime;

                if (fireTime >= FireRate)
                {
                    fireTime = 0f;
                    isFired = false;
                }
            }
            else if (input.F)
            {
                FireMissile();
            }
        }

        if(input.R)
        {
            isStarted = !isStarted;
        }
    }

    void FireMissile()
    {
        isFired = true;

        ++portTurn;
        portTurn = portTurn % Ports.Length;
        GameObject missile = Instantiate(MissilePraf, Ports[portTurn].position, gameObject.transform.rotation);
    }
}
