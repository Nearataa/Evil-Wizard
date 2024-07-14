using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 3f;

    private float currentHealth;

    public bool HasTakeDamage { get; set; }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(float damageAmount)
    {
        HasTakeDamage = true;

        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
