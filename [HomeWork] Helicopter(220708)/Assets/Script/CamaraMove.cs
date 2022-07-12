using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    public GameObject target;

    private Vector3 originalPos;

    private void Start()
    {
        originalPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 differ = target.transform.position - gameObject.transform.position;
        gameObject.transform.position = originalPos + gameObject.transform.position + differ;
    }
}
