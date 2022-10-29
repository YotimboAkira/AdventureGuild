using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerStats playerStats;
    public bool canAttack;
    public int attackDamage;
    private int weaponDamage;
    //private float timer = 2f;
    //public float attackDelay;


    void Start()
    {
        playerStats = GameObject.Find("Player").GetComponent<PlayerStats>();

        attackDamage = playerStats.strBonus + weaponDamage;
    }

    void Update()
    {
        //Attacking
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            Debug.Log("Attack");
            List<Collider2D> hits = new List<Collider2D>();
            ContactFilter2D filter = new ContactFilter2D().NoFilter();


            if (Physics2D.OverlapCollider(GetComponent<Collider2D>(), filter, hits) > 0)
            {
                foreach (Collider2D hit in hits)
                {
                    if (hit.CompareTag("Enemy"))
                    {
                        hit.transform.GetComponent<EnemyStats>().TakeDamage(attackDamage);
                        
                    }

                }
            }     
    
        }
    }
}
