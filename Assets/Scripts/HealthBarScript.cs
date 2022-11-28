using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    public GameObject EnemyAiBenim;
    public void UpdateHealthBar()
    {
        _healthBar.fillAmount = EnemyAiBenim.GetComponent<EnemyAiBenim>().EnemyHealth / EnemyAiBenim.GetComponent<EnemyAiBenim>().EnemyMaxHealth;
    }

}
