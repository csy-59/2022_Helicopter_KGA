using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterMovement : MonoBehaviour
{
    public float MaxPropellerSpeed;

    public float TurnSpeed;
    public float MoveSpeed;
    public float AccelerateSpeed;

    public GameObject MainPropeller;
    public GameObject TailPropeller;

    private HelicopterInput input;
    private Rigidbody rigid;
    private float currentPropellerSpeed;
    private float turn;
    private float move;
    private float accelerate;

    // Start is called before the first frame update
    private void Start()
    {
        input = GetComponent<HelicopterInput>();
        rigid = GetComponent<Rigidbody>();
        currentPropellerSpeed = 0f;
    }

    // Update is called once per frame
    private void Update()
    {
        if(currentPropellerSpeed >= MaxPropellerSpeed && input.IsStared)
        {
            turn = TurnSpeed * input.X;
            gameObject.transform.Rotate(0f, turn, 0f);

            move = MoveSpeed * input.Z * -1;
            rigid.velocity = gameObject.transform.forward * move;

            accelerate = AccelerateSpeed * input.Y;
            rigid.AddForce(0f, accelerate, 0f);
        }
        else
        {
            if (input.IsStared)
            {
                EngineOn();
            }
            else
            {
                EngineOff();
            }
        }

        MainPropeller.transform.Rotate(0f, currentPropellerSpeed, 0f);
        TailPropeller.transform.Rotate(currentPropellerSpeed, 0f, 0f);
    }

    private void EngineOn()
    {
        currentPropellerSpeed += Time.deltaTime;
        if (currentPropellerSpeed > MaxPropellerSpeed)
            currentPropellerSpeed = MaxPropellerSpeed;

        rigid.useGravity = false;
    }
    private void EngineOff()
    {
        currentPropellerSpeed -= Time.deltaTime;
        if (currentPropellerSpeed < 0f)
            currentPropellerSpeed = 0f;

        rigid.useGravity = true;
    }
}
