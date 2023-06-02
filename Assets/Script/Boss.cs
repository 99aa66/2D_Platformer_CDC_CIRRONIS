using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool actionFini;
    public enum BossState
    {
        Jump,
        ThrowShield,
        intro,
        Idle,
    }

    [SerializeField] private BossState currentState;
    private Transform destination;

    private bool isInSecondPhase;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private float jumpHeight;
    [SerializeField] private GameObject player;
    private float stateChangeDelay = 2f; // D�lai entre les changements d'�tat
    private float stateTimer; // Timer pour g�rer les transitions d'�tat
    public Transform groundCheck; // objet qui v�rifie si le joueur touche le sol
    public LayerMask groundLayer; // couche du sol

    [SerializeField] GameObject Shield;
    [SerializeField] Transform ThrowSpawn;
    [SerializeField] Transform ThrowSpawnBas;
    [SerializeField] private bool Throw = true;
    [SerializeField] private bool Jumping = false;
    public Animator anim;
    private SpriteRenderer sr;

    private void Start()
    {
        //sr = GetComponent<SpriteRenderer>();
        sr = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponentInParent<Rigidbody2D>();
        //rb = GetComponentInParent<Rigidbody2D>();
        
        // Initialiser l'�tat du boss
        currentState = BossState.intro;
        isInSecondPhase = false;

        // D�marrer le timer pour le premier changement d'�tat
        stateTimer = stateChangeDelay;
    }

    private void Update()
    {
        // D�cr�menter le timer
        stateTimer -= Time.deltaTime;

        // V�rifier si le timer a atteint z�ro
        if (stateTimer <= 0f)
        {
            // Effectuer un changement d'�tat al�atoire
            ChangeToRandomState();

            // R�initialiser le timer
            stateTimer = stateChangeDelay;
        }
        FacePlayer();

        // V�rifier l'�tat actuel du boss et ex�cuter le code appropri�
        switch (currentState)
        {
            case BossState.Jump:
                // Code pour l'�tat Jump
                Jump();
                break;

            case BossState.ThrowShield:
                // Code pour l'�tat ThrowShield

                ThrowShield();
                break;

            case BossState.intro:
                ActionFini();
                break;

            case BossState.Idle:
                // Code pour l'�tat Idle
                break;
        }
    }

    public void ChangeState(BossState newState)
    {
        // Changer l'�tat du boss
        currentState = newState;
    }

    public void SetDestination(Transform newDestination)
    {
        anim.SetBool("FinAction", false);
        actionFini = false;
        // D�finir une nouvelle destination pour le d�placement du boss
        destination = newDestination;
    }

    public void ThrowShield()
    {
        anim.SetBool("FinAction", false);
        actionFini = false;
        anim.SetBool("Shield", true);

        // Code pour lancer le bouclier
        if (Throw == false)
        {
            int random = Random.Range(0, 2);
            if (random == 0)
            {
                Instantiate(Shield,ThrowSpawn.position,Quaternion.identity);
            }
            else if (random == 1)
            {
                Instantiate(Shield, ThrowSpawnBas.position, Quaternion.identity);
            }
            Throw = true;
        }
        
    }
    public void SetThrow()
    {
        Throw = false;
    }

    public void Jump()
    {
        anim.SetBool("FinAction", false);
        actionFini = false;
        anim.SetBool("Jump", true);
        if (Jumping == false)
        {
            Vector2 direction = player.transform.position - transform.position;


            if (isGrounded)
            {
                rb.AddForce(new Vector2(direction.x, jumpHeight), ForceMode2D.Impulse);
            }
            Jumping = true;

        }
        if (isGrounded == true && Jumping == true) 
        {
            anim.SetBool("Jump", false);
        }
    }

    public void FacePlayer()
    {
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        if (transform.position.x > player.transform.position.x)
        {

            transform.parent.localScale = new Vector2(-0.6263232f, 0.6172416f);
            sr.flipX = true;
            //transform.Rotate(0f, 180f, 0f);
        }
        else
        {
            sr.flipX = false;
            transform.parent.localScale = new Vector2(0.6263232f, 0.6172416f);
            //transform.Rotate(0f, 0f, 0f);

        }
    }
   
    public void ActionFini()
    {
        Debug.Log("fini");
        anim.SetBool("FinAction", true);
        StartCoroutine(Idle());
    }


    public IEnumerator Idle()
    {
        currentState = BossState.Idle;
        anim.SetBool("Jump", false);
        anim.SetBool("Shield", false);
        yield return new WaitForSecondsRealtime(1);
        actionFini = true;
        anim.SetBool("FinAction", true);

    }


    private void ChangeToRandomState()
    {
        if (actionFini)
        {

        // G�n�rer un nombre al�atoire pour s�lectionner un nouvel �tat
            int randomState = Random.Range(0, 2); // 6 est exclus, car il y a 6 �tats possibles

        // Convertir le nombre al�atoire en BossState
            BossState newState = (BossState)randomState;

        // V�rifier si le nouvel �tat est diff�rent de l'�tat actuel
            if (newState != currentState)
            {
                // Changer l'�tat du boss
                currentState = newState;
                Throw = false;
                Jumping = false;
            }
            else if (newState == currentState)
            {
            // Si le nouvel �tat est identique � l'�tat actuel, g�n�rer un nouvel �tat al�atoire
                ChangeToRandomState();
            }
        }

    }
    private void FixedUpdate()
    {
        // v�rifie si le joueur touche le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


}
