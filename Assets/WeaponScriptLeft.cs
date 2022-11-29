using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScriptLeft : MonoBehaviour
{
    public Transform FireBall;
    Rigidbody rb;
    public float speed;
    public Animator myAnimator;
    public Transform transformPos;
    public ParticleSystem particleEffect;
    AudioSource audioSource;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        myAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public void DelayedAttack()
    {
        audioSource.Play();
        myAnimator.Play("LeftAttack");
        Transform Bullet;
        Bullet = Instantiate(FireBall, transformPos.transform.position, Quaternion.identity);
        //Instantiate(particleEffect, transformPos.transform.position, Quaternion.identity);
        Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * speed * 1000);
    }
}
