using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Rigidbody2D rb;
    private float HorizontalMove = 0f;
    private bool FacingRight = true;
    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator anim;
    public int health;


    [Header("Player Movement Settings")]
    [Range(0, 10f)] public float speed = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(health<=0)
        {
            Destroy(gameObject);
        }
        HorizontalMove = Input.GetAxisRaw("Horizontal") * speed;
        if (Input.GetMouseButton(0))
        {
            anim.SetTrigger("attack");
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange,enemy);
            for (int i = 0; i<enemies.Length;i++)
            {
                enemies[i].GetComponent<Enemy>().TakeDamage(damage);
            }
            
        }

        if (HorizontalMove < 0 && FacingRight)
        {
            Flip();
        }
        else if (HorizontalMove > 0 && !FacingRight)
        {
            Flip();
        }
    }

    private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPos.position,attackRange);
        }
    private void FixedUpdate()
    {
        Vector2 targetVelocity = new Vector2(HorizontalMove * 10f, rb.velocity.y);
        rb.velocity = targetVelocity;

    }

    private void Flip()
    {
        FacingRight = !FacingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
