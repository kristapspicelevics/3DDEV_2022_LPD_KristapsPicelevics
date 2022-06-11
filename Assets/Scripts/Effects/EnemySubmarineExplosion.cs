using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySubmarineExplosion : MonoBehaviour
{
    public AudioSource audioSource;
    public GameObject explosion;
    public GameObject smoke;
    private GameObject smok;
    bool spawned;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        var enemy = GameObject.FindWithTag("Enemy");
        var comp = enemy.GetComponent<EnemyHealth>();

        if (enemy.GetComponent<EnemyHealth>() == null)
        {
            Debug.LogError("No EnemyHealth component found.");
        }


        if ((comp.currentHealth > 0 && comp.currentHealth <= 30) && spawned == false)
        {
            smok = Instantiate(smoke, transform.position, Quaternion.identity);

            spawned = true;
        }
        else if (comp.currentHealth <= 0 && spawned == true)
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(expl, 4);
            spawned = false;
            Destroy(smok);
            audioSource.Play();
        }
        if (spawned == true)
        {
            smok.transform.position = transform.position;
        }
    }
}
