using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickUpAndThrow : MonoBehaviour
{
    public float throwForce = 10f;
    private bool isprojectil = false; 
    private Rigidbody2D rb2d;
    public Transform grabCheck;
    public LayerMask GrabLayer; // couche du sol
    public Transform groundCheck;

    private bool isPick;
    private bool reset;
    private Follow Follow;
    [SerializeField] private bool isGrounded = false;















    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Follow = GetComponent<Follow>();
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.G) && !isprojectil)
        {
            PickUp();
            Follow.enabled = false;
            reset = false;
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && isprojectil)
        {
            Throw(); 
        }

        else if (reset== true)
        {
            Debug.Log("beh");
            rb2d.gravityScale = 1;
            if (isGrounded == true)
            {
                transform.parent = null;
            }
            reset = false;
        }

        if (isPick == true)
        {
            PickedUp();
        }
    }
    void PickedUp()
    {
        transform.position = grabCheck.transform.position;
    }
    void PickUp()
    {
        isprojectil = true;
        Follow.enabled = false;
        isPick = true;

    }

    void Throw()
    {
        Debug.Log("throw");
        isPick = false;
        //rb2d.velocity = transform.right * throwForce;
        rb2d.AddForce(grabCheck.transform.up * throwForce, ForceMode2D.Impulse);
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f , GrabLayer);
        if (isGrounded)
        {
            Follow.enabled = true;
            isprojectil = false;
        }
    }
}