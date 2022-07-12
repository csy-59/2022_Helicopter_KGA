using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilePort : MonoBehaviour
{
    public GameObject[] PortsA;
    public GameObject[] PortsB;
    public float FireRate = 1f;

    private HelicopterInput input;
    private float fireTime = 0f;
    private int portTurn = 0;
    private int[] missilesTurn = { 0, 0 };
    private bool isFired = false;

    // Start is called before the first frame update
    private void Start()
    {
        input = gameObject.GetComponent<HelicopterInput>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(input.IsStared)
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
            else if (input.Fire)
            {
                FireMissile();
            }
        }
    }

    private void FireMissile()
    {
        isFired = true;

        ++portTurn;
        portTurn = portTurn % 2;

        if (portTurn == 0)
            MissileActive(portTurn, in PortsA);
        else
            MissileActive(portTurn, in PortsB);
    }

    private void MissileActive(int turn, in GameObject[] Port)
    {
        ++missilesTurn[turn];
        missilesTurn[turn] = missilesTurn[turn] % Port.Length;

        Port[missilesTurn[turn]].gameObject.SetActive(true);
    }
}
