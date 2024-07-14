using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth = 3f;

    private float currentHealth;

    private Animator animator;
    public bool HasTakeDamage { get; set; }

    private void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;
    }

    public void Damage(float damageAmount)
    {
        HasTakeDamage = true;

        animator.SetTrigger("hit");
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        StartCoroutine(Kill(0.6f));
    }

    IEnumerator Kill(float duration)
    {
        animator.SetTrigger("death");
        yield return new WaitForSeconds(duration);
        Destroy(gameObject);
    }
}
