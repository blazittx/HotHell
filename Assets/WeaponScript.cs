using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform FireBall;
    Rigidbody rb;
    public float speed;
    public WeaponScriptLeft weaponScriptLeft;
    Animator animator;
    AudioSource audioSource;
    
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent <Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            int random = Random.Range(0, 2);
            Debug.Log(random);
            if(random == 0)
            {
                weaponScriptLeft.DelayedAttack();
            }
            else
            {
                audioSource.Play();
                animator.Play("RightHandAttackFinal");
                DelayedAttack();
            }
        }
    }
    void DelayedAttack()
    {

        Transform Bullet;
        Bullet = Instantiate(FireBall, transform.position, Quaternion.identity);
        Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * speed);
    }
}
