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
        rigid.velocity = gameObject.transform.forward * Speed;
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
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Helicopter")
        {
            Invoke("Die", 3f);
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }

}
