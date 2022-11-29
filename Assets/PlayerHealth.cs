using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    public float playerMaxHealth;

    [SerializeField] private PlayerHealthBarScript _healthBar;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _healthBar.UpdateHealthBar();

        if (playerHealth <= 0)
        {
            //Playerfuckingddies
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DemonBullet")
        {
            playerHealth -= 10;
        }
    }
}
