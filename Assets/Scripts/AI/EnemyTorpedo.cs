using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTorpedo : MonoBehaviour
{
    public GameObject explosion;
    public AudioSource audioSource;
    public int damage;

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Health>().currentHealth -= damage;
            Explosion();
        }
        else
        {
            Explosion();
        }
        Destroy(gameObject);
        Debug.Log("Yay");
    }

    void Explosion()
    {
        GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity);
        Destroy(gameObject);
        audioSource.Play();
        Destroy(expl, 2);
    }
}
