using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int PlayerHP = 100;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerHP <= 0)
        {
            //Playerfuckingddies
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "DemonBullet")
        {
            PlayerHP -= 10;
        }
    }
}
