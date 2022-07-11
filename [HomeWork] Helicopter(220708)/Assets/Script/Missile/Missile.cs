using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public float MaxDurationTime;
    public float Speed;

    private float currentLifeTime;
    private Rigidbody rigid;
    private Vector3 originalPos;

    // Start is called before the first frame update
    private void OnEnable()
    {
        rigid = GetComponent<Rigidbody>();
        originalPos = transform.position;
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
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.layer);
        if(collision.gameObject.layer != 6)
        {
            Die();
            if(collision.gameObject.name != "Plane")
                collision.gameObject.SetActive(false);
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
        gameObject.transform.position = originalPos;
    }

}
