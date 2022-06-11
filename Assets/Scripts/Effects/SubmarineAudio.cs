using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubmarineAudio : MonoBehaviour
{

    public AudioSource audioSourceShoot;
    bool alreadyAttacked;

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
            }
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
