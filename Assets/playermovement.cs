using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playermovement : MonoBehaviour
{
    public Vector3 move = new Vector3(1f, 0f, 0f);
    public Animator animator;
    public float horizontalDir = 0f;
    public float mS = 1.5f;
    public GameObject player;
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 1;
    public bool parry = false;
    public bool stance = false;
    public int stamina = 3 ;
    public int health = 3;
    public bool guard = false;
    public bool attacking = false;
    public bool died;
    Collider2D enemy;
    private void Start()
    {
        
    }
    void Update()
    {
        horizontalDir = Input.GetAxisRaw("Horizontal") * mS;
        transform.position += move* horizontalDir * Time.deltaTime * mS;
        animator.SetFloat("Speed", Mathf.Abs(horizontalDir));
        if(horizontalDir < 0 && !stance)
        {
            Vector3 side = player.transform.localScale;
            side.x = -1;
            player.transform.localScale = side;
        } else if(horizontalDir > 0)
        {
            Vector3 side = player.transform.localScale;
            side.x = 1;
            player.transform.localScale = side;
        }
        Guard();
        if(Input.GetKeyDown("m") && stance)
        {
            Attack();
        }
        OnGuard();
        Deading();
    }

    void Guard()
    {
        if (Input.GetKeyDown("w") && stamina >0)
        {
            mS = 0.5f;
            stance = true;
            animator.SetBool("Combat", stance);
        }
        else if (Input.GetKeyUp("w"))
        {
            mS = 1.5f;
            stance = false;
            animator.SetBool("Combat", stance);
        }
       
    }
    void Attack()
    {
        animator.SetTrigger("Attack");
        enemy =  Physics2D.OverlapCircle(attackPoint.position,attackRange, enemyLayers);

    }
    public void CalcEnemyDmg()
    {
        if (enemy != null)
        {
            bool failedParry = enemy.GetComponent<enemyBehaviour>().alreadyOnGuard;
            if (!failedParry)
            {
                enemy.GetComponent<enemyBehaviour>().TakeDamage(attackDamage);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    void Parrying()
    {
        parry = true;
    }
    void NotParrying()
    {
        parry = false;
    }
    void AttackAnimation()
    {
        attacking = true;
    }
    void AttackAnimationEnded()
    {
        attacking = false;
    }
    void OnGuard()
    {
        if(stance & !attacking)
        {
            guard = true;
        }
        else
        {
            guard = false;
        }
        
    }
    public void DamageStamina(int damage)
    {
        stamina -= damage;
        if (stamina <=0)
        {
            stance = false;
            animator.SetBool("Combat", stance);
            Invoke("StamRegen", 3);
        }
    }
    public void DamageHealth(int damage)
    {
        animator.SetTrigger("Hurt");
        health-= damage;
    }
    public void StamRegen()
    {
        stamina = 5;
    }

    void Deading()
    {
        if (health <= 0)
        {
            died = true;
        }
        animator.SetBool("DED", died);
        if(died == true)
        {
            Invoke("ReloadScene", 0.75f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
