using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaunchProjectile : MonoBehaviour
{
    public AudioSource audioSourceShoot;
    public Transform bulletSpawnPointLeft;
    public Transform bulletSpawnPointRight;
    public GameObject projectile;
    private GameObject torpedo, torpedo2;
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public float time;
    public float launchVelocity;

    // Start is called before the first frame update
    void Start()
    {
  
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!alreadyAttacked)
            {
                audioSourceShoot.Play();
                torpedo = Instantiate(projectile, bulletSpawnPointLeft.position, bulletSpawnPointLeft.rotation);
                torpedo.GetComponent<Rigidbody>().velocity = bulletSpawnPointLeft.forward * launchVelocity;
                torpedo2 = Instantiate(projectile, bulletSpawnPointRight.position, bulletSpawnPointRight.rotation);
                torpedo2.GetComponent<Rigidbody>().velocity = bulletSpawnPointRight.forward * launchVelocity;
                alreadyAttacked = true;
                Invoke(nameof(ResetAttack), timeBetweenAttacks);
            }
        }
        Destroy(torpedo, time);
        Destroy(torpedo2, time);
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
