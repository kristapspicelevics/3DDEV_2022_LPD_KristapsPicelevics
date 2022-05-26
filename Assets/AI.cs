using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public Transform target;
    public float minDist;
    public float speed;
    private Rigidbody rb;
    public float stabilizationSmoothing;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        var playerPos = target.position;
        playerPos.y = transform.position.y;
        transform.LookAt(playerPos);
        Vector3 direction = target.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, target.position);
        direction.Normalize();
        if (distance > minDist)
            transform.position += direction * speed * Time.deltaTime;

        rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(0, rb.rotation.eulerAngles.y, 0)), stabilizationSmoothing));
    }
}
