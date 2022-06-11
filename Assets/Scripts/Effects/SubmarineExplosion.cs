using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineExplosion : MonoBehaviour
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

        var player = GameObject.FindWithTag("Player");
        var comp = player.GetComponent<Health>();
  
        if (comp.currentHealth <= 0 && spawned == true)
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(expl, 4);
            Destroy(smok);
            spawned = false;
            audioSource.Play();

        }
        else if ((comp.currentHealth > 0 && comp.currentHealth <= 30) && spawned == false)
        {
            smok = Instantiate(smoke, transform.position, Quaternion.identity);

            spawned = true;
        }
        else if (comp.currentHealth >= 30 && spawned == true)
        {
            Destroy(smok);
            spawned = false;
        }
        if (spawned == true)
        {
            smok.transform.position = transform.position;
        }
    }
}
