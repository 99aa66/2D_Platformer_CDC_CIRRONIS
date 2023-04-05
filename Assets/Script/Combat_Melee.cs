using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat_Melee : MonoBehaviour
{
    public Transform Attaque_Position;
    public LayerMask EnemyLayers;

    [SerializeField] private float Attaque_Range=0.5f;
    [SerializeField] private int Attaque_Dommage = 30;

    [SerializeField] private float Attaque_Rate = 2f; 
    private float CooldownAttack=0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= CooldownAttack)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Melee();
                CooldownAttack= Time.time + 1f/Attaque_Rate; //0.5s
            }
        }
    }

    private void Melee()
    {
        Collider2D[] HitEnnemi =Physics2D.OverlapCircleAll(Attaque_Position.position,Attaque_Range,EnemyLayers);
        
        foreach(Collider2D Ennemi in HitEnnemi)
        {
            Ennemi.GetComponent<Enemy_Health>().Damage(Attaque_Dommage);
            Debug.Log("Hit " + Ennemi.name);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (Attaque_Position == null)
            return;

        Gizmos.DrawWireSphere(Attaque_Position.position, Attaque_Range);
    }
}
