using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Commande : MonoBehaviour
{
    private float _input;
    public float moveSpeed = 5f; // vitesse de d�placement
    public float jumpForce = 10f; // force de saut
    public Transform groundCheck; // objet qui v�rifie si le joueur touche le sol
    public LayerMask groundLayer; // couche du sol

    public Animator animator;
    public SpriteRenderer sr;
    private Rigidbody2D rb;
    public bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;

    }

    void FixedUpdate()
    {
        // v�rifie si le joueur touche le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        float Move = _input * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(Move));

        // d�placement horizontal
        rb.velocity = new Vector2(_input * moveSpeed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<float>();
        // Turn
        if (_input != 0)
        {
            if (_input > 0)
            {
                transform.localScale = new Vector2(1, 1); // tourne le personnage � droite
                //sr.flipX = false;
                //transform.Rotate(0f, 180f, 0f);
            }
            else
            {
                transform.localScale = new Vector2(-1, 1); // tourne le personnage � gauche
                //sr.flipX = true;
                //transform.Rotate(0f, 0f, 0f);
            }
        }
    }

    public void Jump(InputAction.CallbackContext context)
    {
        // saut
        if (isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
}
