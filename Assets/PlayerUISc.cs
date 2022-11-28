using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerUISc : MonoBehaviour
{
    public TMP_Text ScoreBoard;
    public int Score;
    void Start()
    {
        
    }
    void Update()
    {
        ScoreBoard.text = Score.ToString();
    }
    public void DamageScoreUpgrade()
    {
        Score += 200;
    }
}
