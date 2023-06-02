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

    private float Speed;
    private bool RestoreTime;

    public void Start()
    {
        RestoreTime = false;
        // le joueur commence avec toute sa vie
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);
    }

    private void Update()
    {
        if (RestoreTime)
        {
            if(Time.deltaTime < 1f) 
            {
                Time.timeScale += Time.deltaTime*Speed ;
            }
            else
            {
                Time.timeScale = 1f;
                RestoreTime = false;
            }
        }
    }

    public void StopTime(float ChangeTime,int RestoreSpeed, float Delay)
    {
        Speed = RestoreSpeed;
        if (Delay > 0)
        {
            StopCoroutine(StartTimeAgain(Delay));
            StartCoroutine(StartTimeAgain(Delay));
        }
        else
        {
            RestoreTime = true;
        }
        Time.timeScale = ChangeTime;
    }

    IEnumerator StartTimeAgain(float amt)
    {
        RestoreTime= true;
        yield return new WaitForSecondsRealtime(amt);
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
            //StopTime(0.05f, 10, 0.1f);
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
