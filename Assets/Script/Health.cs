using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    private int MaxHealth=100;
    bool IsDead = false;

    [SerializeField] private int CurrentHealth;
    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (CurrentHealth <= 0)
        {
            IsDead = true;
            Debug.Log("Il est Mort");
        }
        if (IsDead==true)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int Damage)
    {
        CurrentHealth = CurrentHealth - Damage;
    }
}
