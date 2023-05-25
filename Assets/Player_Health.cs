using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86.Sse4_2;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.UIElements.Experimental;

public class Player_Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    [SerializeField] float invicibilityTimeAfterHit = 2f;
    [SerializeField] float invincibilityFlashDelay = 0.2f;
    [SerializeField] bool isInvincible = false; //perso pas invincible par défaut
    [SerializeField] Transform playerSpawn;
    public HealthBar HealthBar;

    public void Start()
    {
        // le joueur commence avec toute sa vie
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }
    public void HealPlayer(int amount)
    {
        if ((currentHealth + amount) > maxHealth)
        {
            currentHealth = maxHealth; //condition qui empêche de dépasser le nombre maximal de ppints de vie du joueur
        }
        else
        {
            currentHealth += amount;
        }

        HealthBar.SetHealth(currentHealth); // maj barre de vie

    }
    public void TakeDamage(int damage)
    {
        if (!isInvincible)
        {
            currentHealth -= damage;  
            HealthBar.SetHealth(currentHealth);

            if (currentHealth <= 0)
            {
                Die();
                return;
            }
            isInvincible = true;
            StartCoroutine(InvincibilityFlash());
            StartCoroutine(HandleInvincibilityDelay());
        }
    }
    public IEnumerator InvincibilityFlash()
    {
        while (isInvincible)
        {
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
            gameObject.GetComponentInChildren<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
            yield return new WaitForSeconds(invincibilityFlashDelay);
        }
    }
    public IEnumerator HandleInvincibilityDelay()
    {
        yield return new WaitForSeconds(invicibilityTimeAfterHit);
        isInvincible = false;
    }
    public void Die()
    {
        transform.position = playerSpawn.position;
        currentHealth = 100;
    }
}
