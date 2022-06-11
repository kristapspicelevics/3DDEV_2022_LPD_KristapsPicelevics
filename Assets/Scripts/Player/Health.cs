using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;
    public int sceneID;
    bool spawned;
    private IEnumerator coroutine;
    private float waitTime = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Player")
            {
                gameObject.GetComponent<LaunchProjectile>().enabled = false;
                gameObject.GetComponent<SubmarineController>().isDead = true;
                coroutine = GameOver(waitTime, sceneID);
                StartCoroutine(coroutine);
            }
        }
    }

    private IEnumerator GameOver(float waitTime, int sceneID)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(sceneID);
    }

}
