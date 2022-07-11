using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float MaxPropellerSpeed;
    private float CurrentPropellerSpeed;

    public float TurnSpeed;
    public float MoveSpeed;
    public float AccelerateSpeed;

    public GameObject MainPropeller;
    public GameObject TailPropeller;

    private HelicopterInput input;
    private Rigidbody rigid;
    private bool isEngineOn = false;
    private float turn;
    private float move;
    private float accelerate;

    // Start is called before the first frame update
    void Start()
    {
        input = GetComponent<HelicopterInput>();
        rigid = GetComponent<Rigidbody>();
        CurrentPropellerSpeed = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (input.R)
        {
            isEngineOn = !isEngineOn;
        }

        if(CurrentPropellerSpeed >= MaxPropellerSpeed && isEngineOn)
        {
            turn = TurnSpeed * input.X;
            move = MoveSpeed * input.Z * -1;
            accelerate = AccelerateSpeed * input.Y;
            Debug.Log($"{turn}, {move}, {accelerate}");

            gameObject.transform.Rotate(0f, turn, 0f);
            rigid.velocity = gameObject.transform.forward * move;
            rigid.AddForce(0f, accelerate, 0f);
        }
        else
        {
            if (isEngineOn)
            {
                EngineOn();
            }
            else
            {
                EngineOff();
            }
        }

        MainPropeller.transform.Rotate(0f, CurrentPropellerSpeed, 0f);
        TailPropeller.transform.Rotate(CurrentPropellerSpeed, 0f, 0f);
    }

    private void EngineOn()
    {
        CurrentPropellerSpeed += Time.deltaTime;
        if (CurrentPropellerSpeed > MaxPropellerSpeed)
            CurrentPropellerSpeed = MaxPropellerSpeed;

        rigid.useGravity = false;
    }
    private void EngineOff()
    {
        CurrentPropellerSpeed -= Time.deltaTime;
        if (CurrentPropellerSpeed < 0f)
            CurrentPropellerSpeed = 0f;

        rigid.useGravity = true;
    }
}
