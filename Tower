using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public float health;
    
    void FixedUpdate()
    {
        if (health <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            gameObject.SetActive(false);
        }
    }
}
