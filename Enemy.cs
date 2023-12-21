using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public int health;
    public int damage;
    private Player player;

    private void Srart()
    {
        player = FindObjectOfType<Player>();
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if(health<=0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player"))
        {
            player.GetComponent<Player>().TakeDamage(damage);
        }
    }
}
