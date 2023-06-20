using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotGetAttack : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        //Play Hurt anim
        if(currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        //Die Animation
        //Disable Enemy

    }
    
}
