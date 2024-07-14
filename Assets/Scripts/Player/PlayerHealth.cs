using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;

    public int health;
    private Animator anim;

    void Start()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
    }
    public void Update()
    {
        if (health <= 0)
        {

            
            Die();
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        
    }

    void Die()
    {
        anim.SetTrigger("isDead");
        StartCoroutine(Respawn(1f));
    }

    IEnumerator Respawn(float duration)
    {
        yield return new WaitForSeconds(duration);
        anim.SetBool("isDead", false);
        GameManager.Instance.ResetCoins();
        health = maxHealth;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

   /* void Respawn()
    {
        GameManager.Instance.ResetCoins();
        health = maxHealth;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }*/
}
