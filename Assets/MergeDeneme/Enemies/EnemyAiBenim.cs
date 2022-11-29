using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MoreMountains.Feedbacks;

public class EnemyAiBenim : MonoBehaviour
{
    [SerializeField]
    public float minDistance;
    [SerializeField]
    public float shotFrequency;

    public float attackTimer;

    public float attackCooldown;

    public GameObject PlayerTransform;
    public float speed;
    Rigidbody rb;
    Collider col;
    public Transform gunTip;
    public Transform bulletPrefab;
    public Transform particleLocation;
    public bool IsInfected;
    public Material InfectedMaterial;
    Material defaultMaterial;
    [SerializeField]
    public Renderer myRenderer;
    Animator myAnimator;
    public float EnemyHealth;
    public float EnemyMaxHealth;
    bool InAttackState;
    bool EndedSpawnAnim = false;
    public AudioClip DamageSound;
    public AudioClip DeathSound;
    AudioSource audioSource;

    public ParticleSystem hitEffect;



    [SerializeField]
    public MMFeedbacks ShootFeedback;
    [SerializeField] private HealthBarScript _healthBar;
    public Transform ImpactPosition;
    public float Damage;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        PlayerTransform = GameObject.FindWithTag("Player"); 
        myAnimator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
    }

    

    private void Start()
    {
        attackCooldown = 1;
        attackTimer = attackCooldown;

        //StartCoroutine(SpawnFireRate(shotFrequency));
        StartCoroutine(SpawnSpeed());
        myAnimator.Play("Spawn");
        

    }
    private void Update()
    {
        _healthBar.UpdateHealthBar();
        //Debug.Log(InAttackState);
        if (IsInfected)
        {
            myRenderer.material = InfectedMaterial;
        }
        //else myRenderer.material = defaultMaterial;

        transform.LookAt(new Vector3(PlayerTransform.transform.position.x, 0, PlayerTransform.transform.position.z));
        distanceCalculation();
    }
    void distanceCalculation()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, PlayerTransform.transform.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
        float distance = Vector3.Distance(transform.position, PlayerTransform.transform.position);
        //Debug.Log(distance);
        if (distance <= minDistance)
        {
            speed = 0;
            InAttackState = true;
            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else if (attackTimer <= 0)
            {
                AttackState();
                attackTimer = attackCooldown;
            }
        }
        else if(EndedSpawnAnim)
        {
            myAnimator.SetBool("IsFollowing", true);
            myAnimator.SetBool("IsAttacking", false);
            speed = 10;
            InAttackState = false;
        }
    }
    void AttackState()
    {
        myAnimator.SetBool("IsAttacking", true);
        myAnimator.SetBool("IsFollowing", false);
        Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
        Vector3 pos = Vector3.MoveTowards(transform.position, PlayerTransform.transform.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
        
        //Bullet.GetComponent<bullet>().BulletTrace(pos);



    }
    public void EnemyDamaged()
    {
        Damage = Random.Range(50, 100);
        EnemyHealth -= Damage;
        AudioSource.PlayClipAtPoint(DamageSound, PlayerTransform.transform.position);
        

        if (EnemyHealth <= 0)
        {
            AudioSource.PlayClipAtPoint(DeathSound, PlayerTransform.transform.position);
            myAnimator.enabled = false;
            Destroy(gameObject, 3);
        }


    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.tag == "Bullet")
    //    {
    //       // PlayerTransform.GetComponent<PlayerUISc>().DamageScoreUpgrade();
    //        EnemyDamaged(20);
    //
    //    }
    //}
    
    //IEnumerator SpawnFireRate(float FireRateEnemy)
    //{
    //    while(true)
    //    {
    //        yield return new WaitForSeconds(FireRateEnemy);
    //        Instantiate(bulletPrefab, gunTip.position, Quaternion.identity);
    //
    //    }
    //}
    IEnumerator SpawnSpeed()
    {
        speed = 0;
        yield return new WaitForSeconds(3);
        EndedSpawnAnim = true;
        speed = 10;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            Destroy(other.gameObject, 0.2f);
            Instantiate(hitEffect, particleLocation.transform.position, Quaternion.identity);
            EnemyDamaged();
            ShootFeedback?.PlayFeedbacks(ImpactPosition.position, Damage);
        }
        if (other.gameObject.tag == "RevealCone")
        {
            //Instantiate(hitEffect, transform.position, Quaternion.identity);
            IsInfected = true;
        }
    }

}
