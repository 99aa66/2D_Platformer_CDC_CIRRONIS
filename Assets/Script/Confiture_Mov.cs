using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Confiture_Mov : MonoBehaviour
{
    private float _input;
    public float moveSpeed = 5f; // vitesse de déplacement
    public float jumpForce = 10f; // force de saut
    public Transform groundCheck; // objet qui vérifie si le joueur touche le sol
    public LayerMask groundLayer; // couche du sol

    public SpriteRenderer sr;
    private Rigidbody2D rb;
    public bool isGrounded = false;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 3;

    }

    void FixedUpdate()
    {
        // vérifie si le joueur touche le sol
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

        if (isGrounded == false)
        {

            anim.SetBool("Jump", true);

        }
        else anim.SetBool("Jump", false);
        // déplacement horizontal
        rb.velocity = new Vector2(_input * moveSpeed, rb.velocity.y);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _input = context.ReadValue<float>();
        anim.SetFloat("speed",Mathf.Abs(_input));
        // Turn
        if (_input != 0)
        {
            if (_input > 0)
            {
                //transform.localScale = new Vector2(1, 1); // tourne le personnage à droite
                sr.flipX = false;
                //transform.Rotate(0f, 180f, 0f);
            }
            else
            {
                //transform.localScale = new Vector2(-1, 1); // tourne le personnage à gauche
                sr.flipX = true;
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
