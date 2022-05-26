using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{

    public GameObject projectile;
    private GameObject torpedo;
    public float launchVelocity = 700f;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            torpedo = Instantiate(projectile, transform.position,
                                                      transform.rotation);
            torpedo.GetComponent<Rigidbody>().AddRelativeForce(new Vector3
                                                 (0, 0, launchVelocity));
        }
       
    }

    void OnCollisionEnter(Collision collision)
    {
        //Destroy this gameobject
        Destroy(torpedo);
    }

}
