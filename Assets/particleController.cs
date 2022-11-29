using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class particleController : MonoBehaviour
{
    public ParticleSystem particle;
    public GameObject chargeBall;
    public GameObject beam;
    public float FireRate;
    float timer = 5;
    public TMP_Text ChargeValue_Text;
    public AudioSource BeamSound;
    [SerializeField] AudioClip BeamClip;
    bool AudioalreadyPlayed;
    public float ChargeValue = 20;
    [SerializeField] Transform gunAim;
    [SerializeField] LineRenderer lineRend;
    Animator myAnimator;
    Camera cam;
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       
            if (Input.GetMouseButton(1))
            {
                   
                Charging();
                myAnimator.SetBool("BackToIdle", false);
                myAnimator.SetBool("StartAttackBool", true);
                myAnimator.SetBool("KeepAttack", false);



            }
            if (FireRate >= ChargeValue)
            {
                ChargingDone();
                myAnimator.SetBool("StartAttackBool", false);
                myAnimator.SetBool("KeepAttack", true);
                
                


            Invoke("FireRateCharge", .7f);
            
            PlayerRayAttack();
            if (!AudioalreadyPlayed)
            {
                BeamSound.Play();
                AudioalreadyPlayed = true;
                Invoke("audioplayedfalse", 3);
            }
                



        }
        ChargeValue_Text.text = FireRate.ToString();
        




    }
    public void FireRateCharge()
    {
        FireRate = 0;
        
    }
    public void audioplayedfalse()
    {
        AudioalreadyPlayed = false;
    }
    public void Charging()
    {
        if(FireRate <= ChargeValue) FireRate++;
        //AudioalreadyPlayed = false;
        chargeBall.SetActive(false);
        beam.SetActive(false);
        particle.Play();
        
    }

    public void ChargingDone()
    {
        particle.Stop();
        //BeamSound.Play();
        StartCoroutine(ChargeBeamEffect());
    }
    IEnumerator ChargeBeamEffect()
    {
        
        chargeBall.SetActive(true);
        beam.SetActive(true);
        myAnimator.SetBool("BackToIdle", true);
        yield return new WaitForSeconds(.8f);
        chargeBall.SetActive(false);
            beam.SetActive(false);
        


    }
    public void PlayerRayAttack()
    {
        ray = cam.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, 100))
        {

            
                Debug.DrawLine(ray.origin, hit.point, Color.red);
                print(hit.transform.name);
                if (hit.transform.gameObject.tag == "Enemy")
                {
                    Debug.Log("Damaged");
                    hit.transform.GetComponent<EnemyAiBenim>().EnemyDamaged();
                }
            
        }
    }
}
