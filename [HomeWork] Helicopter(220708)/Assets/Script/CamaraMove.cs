using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    public GameObject Target;

    private Vector3 originalPosition;

    private void Start()
    {
        originalPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 differ = Target.transform.position - gameObject.transform.position;
        gameObject.transform.position = originalPosition + gameObject.transform.position + differ;
    }
}
