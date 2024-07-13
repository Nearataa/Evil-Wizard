using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private Transform attackTransform;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private LayerMask attackableLayer;
    [SerializeField] private float damageAmount = 1f;
    [SerializeField] private float timeBtwAttacks = 0.15f;
    
    public bool ShouldBeDamaging { get; private set; } = false;

    private List<IDamageable> iDamageables = new List<IDamageable>();
    
    private RaycastHit2D[] hits;

    private Animator animator;

    private float attackTimeCounter;

    private void Start()
    {
        animator = GetComponent<Animator>();

        attackTimeCounter = timeBtwAttacks;
    }
    private void Update()
    {
        if (UserInput.instance.controls.Attack.Attack.WasPressedThisFrame()  && attackTimeCounter >= timeBtwAttacks)
        {

            attackTimeCounter = 0f;

            //Attack();
            animator.SetTrigger("attack");
        }

        attackTimeCounter += Time.deltaTime;
    }
    /*
    private void Attack()
    {
        hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

        for (int i = 0; i < hits.Length; i++)
        {
            IDamageable iDamagable = hits[i].collider.gameObject.GetComponent<IDamageable>();

            if (iDamagable != null)
            {
                iDamagable.Damage(damageAmount);
            }
        }
    }*/

    public IEnumerator DamageWhileHitIsActive()
    {
        ShouldBeDamaging = true;

        while (ShouldBeDamaging)
        {
            hits = Physics2D.CircleCastAll(attackTransform.position, attackRange, transform.right, 0f, attackableLayer);

            for (int i = 0; i < hits.Length; i++)
            {
                IDamageable iDamageable = hits[i].collider.gameObject.GetComponent<IDamageable>();

                if (iDamageable != null && !iDamageable.HasTakeDamage)
                {
                    //apply damage
                    iDamageable.Damage(damageAmount);
                    iDamageables.Add(iDamageable);
                }
            }

            yield return null;
        }

        AttackableAgain();
    }

    private void AttackableAgain()
    {
        foreach (IDamageable thingWasDamaged in iDamageables)
        {
            thingWasDamaged.HasTakeDamage = false;
        }
        iDamageables.Clear();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackTransform.position, attackRange);   
    }

    #region Animation Triggers

    public void ShouldBeDamagingToTrue()
    {
        ShouldBeDamaging = true;
    }

    public void ShouldBeDamagingToFalse()
    {
        ShouldBeDamaging = false;
    }

    #endregion
}
