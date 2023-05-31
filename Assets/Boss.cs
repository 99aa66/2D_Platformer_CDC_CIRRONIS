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
    private float stateChangeDelay = 3f; // Délai entre les changements d'état
    private float stateTimer; // Timer pour gérer les transitions d'état
    public Transform groundCheck; // objet qui vérifie si le joueur touche le sol
    public LayerMask groundLayer; // couche du sol

    [SerializeField] GameObject Shield;
    [SerializeField] Transform ThrowSpawn;
    [SerializeField] private bool Throw = false;
    [SerializeField] private bool Jumping = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // Initialiser l'état du boss
        currentState = BossState.intro;
        currentHealth = maxHealth;
        isInSecondPhase = false;

        // Démarrer le timer pour le premier changement d'état
        stateTimer = stateChangeDelay;
    }

    private void Update()
    {
        // Décrémenter le timer
        stateTimer -= Time.deltaTime;

        // Vérifier si le timer a atteint zéro
        if (stateTimer <= 0f)
        {
            // Effectuer un changement d'état aléatoire
            ChangeToRandomState();

            // Réinitialiser le timer
            stateTimer = stateChangeDelay;
        }

        // Vérifier l'état actuel du boss et exécuter le code approprié
        switch (currentState)
        {
            case BossState.Jump:
                // Code pour l'état Jump
                Jump();
                break;

            case BossState.Dash:
                // Code pour l'état Dash
                ActionFini();
                break;

            case BossState.ThrowShield:
                // Code pour l'état ThrowShield

                ThrowShield();
                break;

            case BossState.intro:
                ActionFini();
                break;

            case BossState.Idle:
                // Code pour l'état Idle
                break;
        }
    }

    public void ChangeState(BossState newState)
    {
        // Changer l'état du boss
        currentState = newState;
    }

    public void SetDestination(Transform newDestination)
    {
        actionFini = false;
        // Définir une nouvelle destination pour le déplacement du boss
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

        // Générer un nombre aléatoire pour sélectionner un nouvel état
            int randomState = Random.Range(0, 4); // 6 est exclus, car il y a 6 états possibles

        // Convertir le nombre aléatoire en BossState
            BossState newState = (BossState)randomState;

        // Vérifier si le nouvel état est différent de l'état actuel
            if (newState != currentState)
            {
            // Changer l'état du boss
                currentState = newState;
                Throw = false;
                Jumping = false;
            }
            else if (newState == currentState)
            {
            // Si le nouvel état est identique à l'état actuel, générer un nouvel état aléatoire
                ChangeToRandomState();
            }
        }

    }
    private void FixedUpdate()
    {
        // vérifie si le joueur touche le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }


}
