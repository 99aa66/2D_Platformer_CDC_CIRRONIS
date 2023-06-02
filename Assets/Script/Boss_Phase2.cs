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
    private float stateChangeDelay = 3f; // Délai entre les changements d'état
    private float stateTimer; // Timer pour gérer les transitions d'état
    public Transform groundCheck; // objet qui vérifie si le joueur touche le sol
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

        // Initialiser l'état du boss
        currentState = BossState.intro;
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


            case BossState.ThrowLaser:
                // Code pour l'état Dash
                anim.SetBool("Shield", true);
                break;


            case BossState.intro:
                Intro();
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
        // Définir une nouvelle destination pour le déplacement du boss
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
        // Code pour créer un tremblement de terre
        Instantiate(Shield, ThrowSpawn.position, Quaternion.identity);
    }

    private void ChangeToRandomState()
    {
        if (actionFini)
        {

            // Générer un nombre aléatoire pour sélectionner un nouvel état
            int randomState = Random.Range(0, 2); // 6 est exclus, car il y a 6 états possibles

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
