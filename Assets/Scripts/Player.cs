using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity;

public class Player : MonoBehaviour
{
    public float AttackRate = 2f;
    private float AttackTime = 0f;
    public float TPRate = 1f;
    private float TPTime = 0f;
    private float horizontal;
    private float speed = 8f;
    private float AttackRange = 1.2f;
    private bool isFacingRight = true;
    [SerializeField] private Animator Animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform AttackCenter;
    [SerializeField] private Transform PlayerCenter;
    [SerializeField] private Vector2 PlayerBoxSize;
    [SerializeField] private LayerMask EnemyLayer;
    [SerializeField] private Health HP;
    [SerializeField] GameObject SwordSound;
    


    void Update()
    {
        if (!PauseMenu.GamePaused)
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            Animator.SetFloat("Speed", Mathf.Abs(horizontal));
            Flip();
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Time.time >= AttackTime)
                {
                    Animator.SetBool("LeftClickClicked", true);
                    Attack();
                    AttackTime = Time.time + 1f / AttackRate;
                }
            }
            else
            {
                Animator.SetBool("LeftClickClicked", false);
            }
        }


        if (!PauseMenu.GamePaused)
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (currentTeleporter != null)
                {
                    if (Time.time >= TPTime)
                    {
                        transform.position = currentTeleporter.GetComponent<DoorsScript>().GetDestination().position;
                        TPTime = Time.time + 1f / TPRate;
                    }

                }
            }


    }
    void Attack()
    {
        if (!PauseMenu.GamePaused)
        {
            Collider2D[] HitEnemys = Physics2D.OverlapCircleAll(AttackCenter.position, AttackRange, EnemyLayer);
            foreach (Collider2D Enemy in HitEnemys)
            {
                Enemy.GetComponent<Slime>().EnemyTakeDamage();
                Instantiate(SwordSound, transform.position, Quaternion.identity);
            }
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0f || !isFacingRight && horizontal > 0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }
    private GameObject currentTeleporter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Doors"))
        {
            currentTeleporter = collision.gameObject;
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Slime"))
        {
            HP.TakeDamage();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Doors"))
        {
            if (collision.gameObject == currentTeleporter)
            {
                currentTeleporter = null;
            }
        }
    }
    
}




