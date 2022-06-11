using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{

    private Animator thisAnim;

    // Start is called before the first frame update
    void Start()
    {
        thisAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!thisAnim.IsInTransition(0))
        {

            if (Input.GetKey(KeyCode.W))
            {
                thisAnim.CrossFade("Run", 0.2f);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                thisAnim.CrossFade("Walk", 0.2f);
            }
            else
            {
                thisAnim.CrossFade("Idle", 0.2f);
            }
        }
    }
}
