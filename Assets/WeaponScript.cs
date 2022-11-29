using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public Transform FireBall;
    public Transform RevealCone;
    Rigidbody rb;
    public float speed;
    public float coneSpeed;
    public WeaponScriptLeft weaponScriptLeft;
    Animator animator;
    public Transform transformPos;
    public Transform conePos;
    AudioSource audioSource;

    public ParticleSystem particleEffect;
    public ParticleSystem coneEffect;

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
        if (Input.GetMouseButtonDown(1))
        {
            animator.Play("RightHandAttackFinal");
            weaponScriptLeft.myAnimator.Play("LeftAttack");

            Transform Cone;
            Cone = Instantiate(RevealCone, transformPos.transform.position, Quaternion.identity);
            //Instantiate(coneEffect, conePos.transform.position, Quaternion.identity);
            Cone.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * coneSpeed * 1000);
            Destroy(Cone.gameObject, 0.2f);
        }
    }
    public void DelayedAttack()
    {

        Transform Bullet;
        Bullet = Instantiate(FireBall, transformPos.transform.position, Quaternion.identity);
        Instantiate(particleEffect, transformPos.transform.position, Quaternion.identity);
        Bullet.GetComponent<Rigidbody>().AddForce(transform.forward * Time.deltaTime * speed * 1000);
    }
}
