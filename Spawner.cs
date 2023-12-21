using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float timetospawn;
    public GameObject enemyPrefab;
    private float timer, i;

    private void Start()
    {
        timer = timetospawn;
    }

    private void Update()
    {
        if (timer <= 0)
        {
            timer = timetospawn;
            float rand = Random.Range(0, 2);
            while (i < rand)
            {
                GameObject enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
                enemy.transform.position = new Vector3(enemy.transform.position.x + 1, enemy.transform.position.y, 0);
                i++;
            }
            i = 0;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }

}
