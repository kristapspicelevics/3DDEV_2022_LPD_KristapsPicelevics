using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float movSmoothing;
    public float rotSmoothing;

    void Start()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;
    }

    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, movSmoothing);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, rotSmoothing);

    }

}
