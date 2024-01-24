using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage;
    public float speed;
    private float stopTime;
    public float startStopTime;
    public float normalSpeed;
    private Player player;
    private Tower tower;

    private Score sm;

    private float timeBtwAttack;
    public float startTimeBtwAttack;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        normalSpeed = speed;
        sm = FindObjectOfType<Score>();
        tower = FindObjectOfType<Tower>();
    }


    private void Update()
    {
        if (stopTime <= 0)
        {
            speed = normalSpeed;
        }
        else
        {
            speed = 0;
            stopTime -= Time.deltaTime;
        }
        if (health <= 0 )
        {
            sm.Kill();
            Destroy(gameObject);
        }
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }

    public void TakeDamage(int damage)
    {
        stopTime = startStopTime;
        health -=damage;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            if(timeBtwAttack <=0)
            {
                player.health -= damage;
                timeBtwAttack = startTimeBtwAttack;

            }
            else 
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
        if(other.CompareTag("Tower"))
        {
            if(timeBtwAttack <=0)
            {
                tower.health -= damage;
                timeBtwAttack = startTimeBtwAttack;

            }
            else 
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }
    }
}
