using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D EnemyRigidBody2D;
    public int UnitsToMove;
    public float EnemySpeed;
    public bool IsFacingRight;
    public int MaxHP;
    public bool MoveRight = true;
    private float StartPos;
    private float EndPos;
    private int CurrentHP = 0;

    // Use this for initialization
    public void Start()
    {
        
        EnemyRigidBody2D = GetComponent<Rigidbody2D>();
        StartPos = transform.position.x;
        EndPos = StartPos + UnitsToMove;
        IsFacingRight = transform.localScale.x > 0;
        CurrentHP = MaxHP;
    }


    // Update is called once per frame
    public void Update()
    {
        float Random = UnityEngine.Random.Range(UnitsToMove-2,UnitsToMove);
        EndPos = StartPos + Random;
        if (MoveRight)
        {
            EnemyRigidBody2D.velocity = new Vector2 (2f,0f) * EnemySpeed;
            if (!IsFacingRight)
                Flip();
        }

        if (EnemyRigidBody2D.position.x >= EndPos)
            MoveRight = false;

        if (!MoveRight)
        {
            EnemyRigidBody2D.velocity = new Vector2 (-2f,0f) * EnemySpeed;
            if (IsFacingRight)
                Flip();
        }
        if (EnemyRigidBody2D.position.x <= StartPos)
            MoveRight = true;


    }

    public void Flip()
    {
        transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
        IsFacingRight = transform.localScale.x > 0;
    }
    public void EnemyTakeDamage()
    {
        CurrentHP = CurrentHP - 1;
        if (CurrentHP == 0)
        {
            Die();
        }
    }
    void Die()
    {
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
        float  Rand = UnityEngine.Random.Range(1f ,4f );
        if (Mathf.Round(Rand * 1.0f) * 1f == 1)
        Health.CurrentHealth += 1;
        Debug.Log(Mathf.Round(Rand * 1.0f) * 1f);
    }

}

