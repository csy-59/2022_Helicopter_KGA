using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float MaxDurationTime;
    public float Speed;

    private float currentLifeTime;
    private Rigidbody rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.velocity = gameObject.transform.forward * Speed * -1;
        currentLifeTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(currentLifeTime < MaxDurationTime)
        {
            currentLifeTime += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        if(collision.gameObject.layer != 6)
        {
            Destroy(gameObject);
            if(collision.gameObject.name != "Plane")
                collision.gameObject.SetActive(false);
        }
    }

}
