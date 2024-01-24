using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private float timeBtwAttack;
    public float health;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;

    private Rigidbody2D rb;
    private Animator anim;
    public bool facingRight = true;
   
    private void Start()
    {
        anim = GetComponent<Animator>();
        rb =  GetComponent<Rigidbody2D>();
    }

    
    void FixedUpdate()
    {
        if (health <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            gameObject.SetActive(false);
        }
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
        if (timeBtwAttack <= 0)
        {
            if ( Input.GetMouseButton(0))
            {
                anim.SetTrigger("attack");
            }
        }
        
    }
    public void OnAttack()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
            for (int i = 0; i<enemies.Length;i++)
            {
                enemies[i].GetComponent<Enemy>().TakeDamage(damage);
            }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position,attackRange);
    }
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}
