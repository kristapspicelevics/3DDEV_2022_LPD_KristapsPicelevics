using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterParticles : MonoBehaviour
{

    public GameObject water;
    bool spawned;
    private GameObject waterPart;

    // Start is called before the first frame update
    void Start()
    {
        spawned = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned == false)
        {
            waterPart = Instantiate(water, transform.position, Quaternion.identity);

            spawned = true;
        }
        
        var player = GameObject.FindWithTag("Player");
        var comp = player.GetComponent<Health>();

        if (comp.currentHealth <= 0)
        {
            Destroy(waterPart);
            spawned = false;
        }
        if (spawned == true)
        {
            waterPart.transform.position = transform.position;
            waterPart.transform.rotation = transform.rotation;
        }
    }
}
