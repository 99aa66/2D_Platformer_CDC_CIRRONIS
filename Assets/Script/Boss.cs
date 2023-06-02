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
    private float stateChangeDelay = 2f; // Délai entre les changements d'état
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
        FacePlayer();

        // Vérifier l'état actuel du boss et exécuter le code approprié
        switch (currentState)
        {
            case BossState.Jump:
                // Code pour l'état Jump
                Jump();
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
        anim.SetBool("FinAction", false);
        actionFini = false;
        // Définir une nouvelle destination pour le déplacement du boss
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
