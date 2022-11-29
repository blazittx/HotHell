using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarScript : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    public GameObject PlayerHealth;
    public void UpdateHealthBar()
    {
        _healthBar.fillAmount = PlayerHealth.GetComponent<PlayerHealth>().playerHealth / PlayerHealth.GetComponent<PlayerHealth>().playerMaxHealth;
    }

}
