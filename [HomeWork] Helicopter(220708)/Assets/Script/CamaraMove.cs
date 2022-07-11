using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraMove : MonoBehaviour
{
    public GameObject target;

    private float originalX;
    private float originalY;
    private float originalZ;

    private void Start()
    {
        originalX = gameObject.transform.position.x;
        originalY = gameObject.transform.position.y;
        originalZ = gameObject.transform.position.z;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float differX = target.transform.position.x - gameObject.transform.position.x;
        float differY = target.transform.position.y - gameObject.transform.position.y;
        float differZ = target.transform.position.z - gameObject.transform.position.z;

        gameObject.transform.position = new Vector3(originalX + gameObject.transform.position.x + differX,
            originalY + gameObject.transform.position.y + differY, originalZ + gameObject.transform.position.z + differZ);
    }
}
