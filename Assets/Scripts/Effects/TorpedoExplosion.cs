using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorpedoExplosion : MonoBehaviour
{

    public AudioSource audioSource;

    private void OnCollisionEnter(Collision collision)
    {
        audioSource.Play();
    }
}
