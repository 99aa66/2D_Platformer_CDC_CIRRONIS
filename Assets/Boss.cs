using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public bool actionFini;
    public enum BossState
    {
        Jump,
        Dash,
        MoveToDestination,
        ThrowShield,
        intro,
        Idle,
    }

    [SerializeField] private BossState currentState;
    private Transform destination;
    private int currentHealth;
    private int maxHealth = 100;
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
    [SerializeField] private bool Throw = false;
    [SerializeField] private bool Jumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Initialiser l'�tat du boss
        currentState = BossState.intro;
        currentHealth = maxHealth;
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

            case BossState.Dash:
                // Code pour l'�tat Dash
                ActionFini();
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
        actionFini = false;
        // D�finir une nouvelle destination pour le d�placement du boss
        destination = newDestination;
    }

    public void ThrowShield()
    {
        actionFini = false;
        // Code pour lancer le bouclier
        if (Throw == false)
        {
            Instantiate(Shield,ThrowSpawn.position,Quaternion.identity);
            Throw = true;
        }
        ActionFini();
    }

    public void Jump()
    {
        actionFini = false;
        if (Jumping == false)
        {
            Jumping = true;
            Vector2 direction = player.transform.position - transform.position;


            if (isGrounded)
            {
                rb.AddForce(new Vector2(direction.x, jumpHeight), ForceMode2D.Impulse);
            }

        }

        ActionFini();

    }

    public void FacePlayer()
    {

    }

    public void ActionFini()
    {
        StartCoroutine(Idle());
    }


    public IEnumerator Idle()
    {
        yield return new WaitForSeconds(3);
        actionFini = true;
        
    }


    private void ChangeToRandomState()
    {
        if (actionFini)
        {

        // G�n�rer un nombre al�atoire pour s�lectionner un nouvel �tat
            int randomState = Random.Range(0, 4); // 6 est exclus, car il y a 6 �tats possibles

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
