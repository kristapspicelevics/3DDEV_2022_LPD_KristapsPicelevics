using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineController : MonoBehaviour
{

    public float speedChange;
    public float maxForwardSpeed;
    public float maxBackwardSpeed;
    public float minSpeed;
    public float turnSpeed;
    public float riseSpeed;
    public float stabilizationSmoothing;

    private float currSpeed;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        Turn();
        Rise();
        Stabilize();
    }

    void Move() 
    {
        if (Input.GetKey(KeyCode.W))
        {
            currSpeed += speedChange;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            currSpeed -= speedChange;
        }
        else if (currSpeed <= minSpeed)
        {
            currSpeed = 0f;
        }
        else
        {
            currSpeed -= speedChange / 4;
        }
        currSpeed = Mathf.Clamp(currSpeed, -maxBackwardSpeed, maxForwardSpeed);
        rb.AddForce(transform.forward * currSpeed);
    }

    void Turn() 
    {
        if (Input.GetKey(KeyCode.D))
        {
            rb.AddTorque(transform.up * turnSpeed);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb.AddTorque(transform.up * -turnSpeed);
        }
    }

    void Rise() 
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            //    rb.AddTorque(transform.right * riseSpeed / 10);
            rb.AddForce(transform.up * riseSpeed);
        }
        else if (Input.GetKey(KeyCode.DownArrow))
        {
            //    rb.AddTorque(transform.right * -riseSpeed / 10);
            rb.AddForce(transform.up * -riseSpeed);
        }
    }

    void Stabilize() 
    {
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(rb.rotation.eulerAngles.x, rb.rotation.eulerAngles.y, rb.rotation.eulerAngles.z)), stabilizationSmoothing));
    }
}
