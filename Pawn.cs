using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : MonoBehaviour
{
    [SerializeField]
    protected float health = 100f;

    [SerializeField]
    protected float speed = 6f;

    [SerializeField]
    protected float damage = 25f;

    public virtual void TakeDamage(float damage) 
    {
        health -= damage;
        if (health <= 0)
            Die();
    }

    public virtual void Die() 
    {
        Destroy(gameObject);
    }
    public virtual void Move()
    {

    }
}
