using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class HealthController : MonoBehaviour
{
    public int healthStart;
    public int currentHealth;

    // Start is called before the first frame update
    virtual public void Start()
    {
        ResetHealth();
    }

    public void ResetHealth()
    {
        currentHealth = healthStart;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    public virtual void HealDamage(int healAmount)
    {
        currentHealth += healAmount;

        if (currentHealth > healthStart)
        {
            ResetHealth();
        }
    }
}
