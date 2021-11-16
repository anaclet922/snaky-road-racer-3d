using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    Vector3 distance;
    public float smoothValue;
    void Start()
    {
        distance = target.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(target.position.y >= 0)
        {
            Follow();
        }
    }

    void Follow()
    {
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = target.position - distance;
        transform.position = Vector3.Lerp(currentPosition, targetPosition, smoothValue * Time.deltaTime);

    }
}
