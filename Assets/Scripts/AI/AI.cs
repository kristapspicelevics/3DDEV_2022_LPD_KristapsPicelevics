using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI : MonoBehaviour
{

    public Transform target;
    public float speed, rotSpeed;
    private Rigidbody rb;
    public Transform bulletSpawnPointLeft, bulletSpawnPointRight;
    public float stabilizationSmoothing;

    //Patroling
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private float waitTime = 2f; // in seconds
    private float waitCounter = 0f;
    private bool waiting = false;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    private GameObject torpedo, torpedo2;
    public float launchVelocity;
    public float projectileTime;

    //States
    public float sightRange, attackRange;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {

        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        var player = GameObject.FindWithTag("Player");
        var comp = player.GetComponent<SubmarineController>();

        Vector3 direction = target.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, target.position);
        direction.Normalize();
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(0, rb.rotation.eulerAngles.y, 0)), stabilizationSmoothing));

        if (distance > sightRange)
        {
            Patroling();
        }

        if (distance < sightRange && distance > attackRange && comp.isDead == false) {
            ChasePlayer();
            currentWaypointIndex = 0;
        }

        if (distance < attackRange && comp.isDead == false)
        {
            AttackPlayer();
        }
    }

    private void Patroling()
    {
        Transform wp = waypoints[currentWaypointIndex];
        if (waiting)
        {
            waitCounter += Time.deltaTime;
            int nextWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            Transform wpNext = waypoints[nextWaypointIndex];


            var targetPoint = wpNext.position;
            var targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
            Debug.Log(targetRotation);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
            if (waitCounter < waitTime)
                return;
            waiting = false;
        }

        

        if (Vector3.Distance(transform.position, wp.position) == 0f)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            waitCounter = 0f;
            waiting = true;
            Debug.Log("Waypoint");
        }
        else
        {
            transform.LookAt(wp.position);
            transform.position = Vector3.MoveTowards(transform.position, wp.position, speed / 3 * Time.deltaTime); 
        }
    }

    private void ChasePlayer()
    {

        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        Vector3 direction = target.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, target.position);

        var targetPoint = targetPosition;
        var targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
   
        direction.Normalize();
        rb.MovePosition(rb.position + direction * speed * Time.deltaTime);
        rb.MoveRotation(Quaternion.Slerp(rb.rotation, Quaternion.Euler(new Vector3(0, rb.rotation.eulerAngles.y, 0)), stabilizationSmoothing));
    }

    private void AttackPlayer()
    {
        Vector3 targetPosition = new Vector3(target.position.x, transform.position.y, target.position.z);
        var targetPoint = targetPosition;
        var targetRotation = Quaternion.LookRotation(targetPoint - transform.position, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotSpeed);
        Vector3 direction = target.transform.position - transform.position;
        float distance = Vector3.Distance(transform.position, target.position);
        direction.Normalize();
        if (target.position.y > transform.position.y)
        {
        //    rb.AddForce(transform.up * speed/2);
            rb.MovePosition(rb.position + transform.up * speed /3 * Time.deltaTime);
        }
        else if (target.position.y < transform.position.y)
        {
         //   rb.AddForce(transform.up * -speed / 2);
            rb.MovePosition(rb.position + transform.up * -speed / 3 * Time.deltaTime);
        }
        else if (target.position.y == transform.position.y)
        {
            //   rb.AddForce(transform.up * -speed / 2);
            rb.MovePosition(rb.position + transform.up * 0f);
        }
        if (!alreadyAttacked)
        {
            ///Attack code here
            torpedo = Instantiate(projectile, bulletSpawnPointLeft.position, bulletSpawnPointLeft.rotation);
            torpedo.GetComponent<Rigidbody>().velocity = bulletSpawnPointLeft.forward * launchVelocity;
            torpedo2 = Instantiate(projectile, bulletSpawnPointRight.position, bulletSpawnPointRight.rotation);
            torpedo2.GetComponent<Rigidbody>().velocity = bulletSpawnPointRight.forward * launchVelocity;
            ///End of attack code
            Destroy(torpedo, projectileTime);
            Destroy(torpedo2, projectileTime);
            alreadyAttacked = true;
            coroutine = ResetAttack(timeBetweenAttacks);
            StartCoroutine(coroutine);
        }
            //Make sure enemy doesn't move
    }

    private IEnumerator ResetAttack(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        alreadyAttacked = false;
    }

}
