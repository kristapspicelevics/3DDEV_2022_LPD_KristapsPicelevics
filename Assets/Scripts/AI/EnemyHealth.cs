using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    public AudioSource audioSource;
    public GameObject explosion;
    public GameObject smoke;
    private GameObject smok;
    bool spawned;



    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if ((currentHealth > 0 && currentHealth <= 30) && spawned == false)
        {
            smok = Instantiate(smoke, transform.position, Quaternion.identity);
            if (spawned == true)
            {
                smok.transform.position = transform.position;
            }
            spawned = true;
        }
        else if (currentHealth <= 0 && spawned == true)
        {
            GameObject expl = Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(expl, 4);
            spawned = false;
            Destroy(smok);
            if (gameObject.tag == "Enemy")
            {
                Destroy(this.gameObject);
                AddScore(1000);
            }
            audioSource.Play();
        }

    }

    void AddScore(int value)
    {
        var score = GameObject.FindWithTag("Score");
        var comp = score.GetComponent<ScoreManager>();
        comp.score = comp.score + value;
        ScoreManager.instance.AddPoints();
    }

}
