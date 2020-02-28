using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyBehaviour : MonoBehaviour
{
    public Animator animator;
    public int health = 3;
    public Transform dangerZone;
    public float dangerRange = 0.5f;
    public LayerMask playerLayer;
    public bool alreadyOnGuard = false;
    public Collider2D playerPresent;
    public int damage = 1;
    public bool cooldown = true;
    public int attackCounter = 0;
    void Start()
    {
        AttackInitiator();
        IsOnGuard();
    }

    private void Update()
    {
        playerPresent = Physics2D.OverlapCircle(dangerZone.position, dangerRange, playerLayer);
        animator.SetBool("Danger", alreadyOnGuard);
    }
    public void IsOnGuard()
    {
        if (playerPresent != null)
        {
            if (!alreadyOnGuard)
            {
                alreadyOnGuard = true;
            }
        }
        Invoke("IsOnGuard", 2f);
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        animator.SetTrigger("Hurting");
        if (health <= 0)
        {
            Die();
        }
    }
    void Die()
    {
        animator.SetBool("Died", true);
        Invoke("ReloadScene", 0.75f);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(dangerZone.position, dangerRange);
    }

    public void AttackInitiator()
    {
        //int randomizer = Random.Range(500, 1500);
        if(playerPresent != null)
        {
            if (attackCounter == 0)
            {
                cooldown = false;
                animator.SetTrigger("Swing");
            }
        }
        Invoke("AttackInitiator", 1.75f);
        //Invoke("AttackInitiator", 0.002f * randomizer);
    }
    public void DamagePlayer()
    {
        if (playerPresent != null)
        {
            bool parried = playerPresent.gameObject.GetComponent<playermovement>().parry;
            if (parried == true)
            {
                alreadyOnGuard = false;
            }
            if (!parried)
            {
                bool blocked = playerPresent.gameObject.GetComponent<playermovement>().guard;
                if (blocked)
                {
                    playerPresent.gameObject.GetComponent<playermovement>().DamageStamina(damage);
                }
                else if (!blocked)
                {
                   
                    playerPresent.gameObject.GetComponent<playermovement>().DamageHealth(damage);

                }

            }
        }
    }
    public void Cooldown()
    {
        cooldown = true;
    }
    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
