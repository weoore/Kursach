using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameover : MonoBehaviour
{
   public TextMeshProUGUI gameOverText;
   private Tower tower;
    private void Start()
    {
        tower = FindObjectOfType<Tower>();
    }
   public void Update()
   {
        if (tower.health <= 0)
        {
            gameOverText.text = "Игра окончена. Вы проиграли!";
        }
   }
}
