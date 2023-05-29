using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class IAJump: MonoBehaviour
{
    public Transform groundDetection;
    public Transform obstacleDetection;
    private Transform target;
    private bool isFacingRight = true;
    public LayerMask Default;
    [SerializeField]private bool isGrounded;
    private bool isObstacleAhead;
    public float moveSpeed = 3f;
    private float moveDirection = 1;
    [SerializeField] float circleRadius;

    [SerializeField] float jumpHeight;
    [SerializeField] Transform Player;
    [SerializeField] Transform groundCheck;
    [SerializeField] Vector2 boxSize;
    private bool isOnGround;

    private int damageOnCollision = 20;
    [SerializeField] Player_Health health;

    private Animator enemyAnim;


    [SerializeField] Vector2 lineOfSite;
    private bool isPlayerDetected;
    [SerializeField] LayerMask playerLayer;

    private int JumpAttackCount;

    private Rigidbody2D RB;
    void Start()
    {
        enemyAnim= GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        // Détection du sol, des obstacles et du joueur
        isGrounded = Physics2D.OverlapCircle(groundDetection.position, circleRadius, Default);
        isObstacleAhead = Physics2D.OverlapCircle(obstacleDetection.position, circleRadius, Default);
        isOnGround = Physics2D.OverlapBox(groundCheck.position, boxSize, 0, Default);
        isPlayerDetected = Physics2D.OverlapBox(transform.position, lineOfSite, 0, playerLayer);
       
        if(!isPlayerDetected && isOnGround) 
        {
            Patrouille();
        }
        else if (isPlayerDetected && isOnGround)
        {
            FlipTowardsPlayer();
        }
        AnimationController();

    }
    void Patrouille()
    {
        if (!isGrounded || isObstacleAhead)
        {
            if (isFacingRight)
            {
                Flip();
            }
            else if (!isFacingRight)
            {
                Flip();
            }
        }
        RB.velocity = new Vector2(moveSpeed * moveDirection, RB.velocity.y);
    }
    public void JumpAttack()
    {
        float distanceFromPlayer = Player.position.x - transform.position.x;
        if (isOnGround)
        {
            RB.AddForce(new Vector2(distanceFromPlayer, jumpHeight), ForceMode2D.Impulse); 
        }
    }
    void FlipTowardsPlayer()
    {
        float playerPosition = Player.position.x - transform.position.x;
        if (playerPosition < 0 && isFacingRight)
        {
            Flip();
        }
        else if (playerPosition > 0 && !isFacingRight)
        {
            Flip();
        }
    }
    void Flip()
    {
        moveDirection *= -1;
        isFacingRight = !isFacingRight;
        transform.Rotate(0, 180, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            bool isAttacking = false;

            if (!isAttacking)
            {
                health.TakeDamage(damageOnCollision);
            }
        }
    }

    void AnimationController()
    {
        enemyAnim.SetBool("canSeePlayer", isPlayerDetected);
        enemyAnim.SetBool("isGrounded", isOnGround);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(groundDetection.position, circleRadius);
        Gizmos.DrawWireSphere(obstacleDetection.position, circleRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawCube(groundCheck.position, boxSize);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, lineOfSite);
    }
}