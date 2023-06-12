using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeWeapon : MonoBehaviour
{
    public float defaultForce = 300;
    public float upwardsForce = 150;

    private float movementTime=0.1f;
    public bool HitEnnemiBas;
    public bool HitEnnemicot;
    public bool HitEnnemiHaut;

    public Transform Attaque_Bas;
    public Transform Attaque_Haut;
    public Transform Attaque_Cot;

    public LayerMask EnemyLayers;

    [SerializeField] private float Attaque_Range = 0.5f;
    private float CooldownAttack = 0;
    [SerializeField] private float Attaque_Rate = 2f;

    [SerializeField] private int damageAmount = 20;

    private Player_Commande character;
    private Rigidbody2D rb;
    public Animator anim;


    private Vector2 direction;
    [SerializeField] private bool collided = false;
    private bool downwardStrike;

    private void Start()
    {
        character = GetComponent<Player_Commande>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Time.time >= CooldownAttack)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Melee();
                CooldownAttack = Time.time + 1f / Attaque_Rate; //0.5
            }
        }
        //if (HitEnnemiBas || HitEnnemicot || HitEnnemiHaut)
        //{
        //    collided = true;
        //}
    }

    private void FixedUpdate()
    {
        if (collided)
        {
            if (downwardStrike)
            {
                rb.AddForce(direction * upwardsForce);
            }
            else
            {
                rb.AddForce(direction * defaultForce);
            }
        }
        if(downwardStrike == true)
        {
            anim.SetBool("Atk_Bas", true);
        }
    }

    private void Melee()
    {
        if (Time.time >= CooldownAttack)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                MeleeAtk();
                CooldownAttack = Time.time + 1f / Attaque_Rate; //0.5s
                
            }
        }
    }

    private void MeleeAtk()
    {
        HitEnnemiBas = Physics2D.OverlapCircle(Attaque_Bas.position, Attaque_Range, EnemyLayers);
        HitEnnemicot = Physics2D.OverlapCircle(Attaque_Cot.position, Attaque_Range, EnemyLayers);
        HitEnnemiHaut = Physics2D.OverlapCircle(Attaque_Haut.position, Attaque_Range, EnemyLayers);

        if (HitEnnemiBas && Input.GetAxis("Vertical") < 0 && !character.isGrounded)
        {
           
            direction = Vector2.up;
            downwardStrike = true;
            
            


            Collider2D[] HitEnnemi = Physics2D.OverlapCircleAll(Attaque_Bas.position, Attaque_Range, EnemyLayers);

            

            foreach (Collider2D Ennemi in HitEnnemi)
            {

                Debug.Log("Bahhh");
                Ennemi.GetComponent<Enemy_Health>();
                
                if (Ennemi.GetComponent<Enemy_Health>() == true)
                {
                    Debug.Log(HitEnnemi);
                    if (collided == false && HitEnnemiBas && !character.isGrounded)
                    {
                        collided = true;
                    }
                    Ennemi.GetComponent<Enemy_Health>().Damage(damageAmount);
                    Debug.Log("Hit " + Ennemi.name);
                }
                else
                {
                    Debug.Log("OLM");
                }
            }
        }
        //else if (Input.GetAxis("Vertical") > 0 && !character.isGrounded)
        //{
        //    direction = Vector2.down;

            

        //    Collider2D[] HitEnnemi = Physics2D.OverlapCircleAll(Attaque_Haut.position, Attaque_Range, EnemyLayers);

        //    foreach (Collider2D Ennemi in HitEnnemi)
        //    {
        //        Debug.Log(HitEnnemi);
        //        Ennemi.GetComponent<Enemy_Health>();

        //        if (Ennemi.GetComponent<Enemy_Health>())
        //        {
        //            if (collided == false && HitEnnemiHaut)
        //            {
        //                collided = true;
        //            }
        //            Ennemi.GetComponent<Enemy_Health>().Damage(damageAmount);
        //            Debug.Log("Hit " + Ennemi.name);
        //        }
        //    }
        //}


         if ((Input.GetAxis("Vertical") <= 0 && character.isGrounded)/* || Input.GetAxis("Vertical") == 0*/)
        {
            anim.SetBool("Atk_Cot", true);
            if (transform.localScale.x < 0) 
            {
                direction = Vector2.right;
            }
            else
            {
                direction = Vector2.left;
            }


            Collider2D[] HitEnnemi = Physics2D.OverlapCircleAll(Attaque_Cot.position, Attaque_Range, EnemyLayers);

            foreach (Collider2D Ennemi in HitEnnemi)
            {
                Debug.Log(HitEnnemi);
                Ennemi.GetComponent<Enemy_Health>();

                if (Ennemi.GetComponent<Enemy_Health>())
                {
                    if (collided == false && HitEnnemiHaut)
                    {
                        collided = true;
                    }
                    //if (transform.position.x > Ennemi.transform.position.x)
                    //{

                    //    Ennemi.GetComponent<Rigidbody2D>().velocity = (-Vector2.right * 200 * Time.deltaTime);
                    //}
                    //else
                    //{
                    //    Ennemi.GetComponent<Rigidbody2D>().velocity = (Vector2.right * 200 * Time.deltaTime);
                    //}
                    Ennemi.GetComponent<Enemy_Health>().Damage(damageAmount);
                    Debug.Log("Hit " + Ennemi.name);
                }
            }

        }

        StartCoroutine(NoLongerColliding());
    }

    
    private IEnumerator NoLongerColliding()
    {
        
        yield return new WaitForSeconds(movementTime);
        anim.SetBool("Atk_Cot", false);
        anim.SetBool("Atk_Bas", false);
        Debug.Log("Strop");
        collided = false;

        downwardStrike = false;

        HitEnnemiBas = false;

        HitEnnemiHaut = false;

        HitEnnemicot = false;
    }
}