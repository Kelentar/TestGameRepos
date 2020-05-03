using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{

    public int health = 100;
    public int currentHealth;
    public Animator anim;

    public HealthBar healthBar;

    public void Start()
    {
        currentHealth = health;
        healthBar.SetMaxHealth(health);
    }

    public void Update()
    {
        if(Input.GetButtonDown("Fire2"))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        anim.SetTrigger("HitEffect");
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            anim.SetBool("Dead", true);
            Die();
        }
    }

    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}