using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreDisplay;


    private void Update()
    {
        scoreDisplay.text = "Счет: " + score.ToString();  
    }
    public void Kill()
    {
        score++;
    }
}
