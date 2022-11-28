using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightHandAnimController : MonoBehaviour
{
    Animator myAnimator;
    void Start()
    {
        myAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //myAnimator.SetBool("Idle", false);
            //myAnimator.SetTrigger("Attack");
            myAnimator.Play("RightHandAttackFinal");
        }
        else
           myAnimator.SetBool("Idle", true);
    }
}
