using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Phase2 : MonoBehaviour
{
    public enum BossState
    {
        Jump,
        ThrowLaser,
        intro,
        Idle,
    }

    public bool actionFini;
    [SerializeField] private BossState currentState;
    private Transform destination;

    private bool isInSecondPhase;
    private Rigidbody2D rb;
    private bool isGrounded;
    [SerializeField] private float jumpHeight;
    [SerializeField] private GameObject player;
    private float stateChangeDelay = 3f; // D�lai entre les changements d'�tat
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
        anim.SetBool("Phase2", true);
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

        // V�rifier l'�tat actuel du boss et ex�cuter le code appropri�
        switch (currentState)
        {
            case BossState.Jump:
                // Code pour l'�tat Jump
                Jump();
                break;


            case BossState.ThrowLaser:
                // Code pour l'�tat Dash
                anim.SetBool("Shield", true);
                break;


            case BossState.intro:
                Intro();
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
        // D�finir une nouvelle destination pour le d�placement du boss
        destination = newDestination;
        ChangeToRandomState();
    }
    public IEnumerator Intro()
    {

        GetComponentInParent<Enemy_Health>().damageable = false;
        yield return new WaitForSecondsRealtime(1);
        Idle();
        anim.SetBool("Idle", true);
    }

    public IEnumerator Idle()
    {
        GetComponentInParent<Enemy_Health>().damageable = true;
        currentState = BossState.Idle;
        anim.SetBool("Jump", false);
        anim.SetBool("Shield", false);
        yield return new WaitForSecondsRealtime(1);
        actionFini = true;
        anim.SetBool("FinAction", true);

    }
    public void ActionFini()
    {
        Debug.Log("fini");
        anim.SetBool("FinAction", true);
        StartCoroutine(Idle());
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
                rb.AddForce(new Vector2(direction.x * 40, jumpHeight), ForceMode2D.Impulse);
            }
            Jumping = true;

        }
        if (isGrounded == true && Jumping == true)
        {
            anim.SetBool("Jump", false);
        }
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
                Instantiate(Shield, ThrowSpawn.position, Quaternion.identity);
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

    public void ThrowLaser()
    {
        // Code pour lancer le laser
    }
    private void CreateEarthquake()
    {
        // Code pour cr�er un tremblement de terre
        Instantiate(Shield, ThrowSpawn.position, Quaternion.identity);
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
