using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickUpAndThrow : MonoBehaviour
{
    public float throwForce = 10f;
    private bool isPickedUp = false; 
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
        isPick = Physics2D.OverlapCircle(grabCheck.position, 0.2f, GrabLayer);
        if (Input.GetKeyDown(KeyCode.G) && !isPickedUp)
        {
            PickUp();
            Follow.enabled = false;
            rb2d.gravityScale = 0;
            reset = false;
        }

        else if (Input.GetKeyDown(KeyCode.Mouse0) && isPickedUp)
        {
            Throw(); 
        }

        else if (reset== true)
        {
            Debug.Log("beh");
            rb2d.gravityScale = 1;
            if (isGrounded == true)
            {
                Follow.enabled = true;
                transform.parent = null;
            }
            reset = false;
        }
    }

    void PickUp()
    {

        transform.parent = grabCheck.transform; 
        transform.localPosition = new Vector2(0.5f, 0.5f); 
        isPickedUp = true;

    }

    void Throw()
    {

        transform.parent = null;
        rb2d.velocity = transform.right * throwForce;
        //rb2d.AddForce(grabCheck.transform.up * throwForce, ForceMode2D.Impulse);
        isPickedUp = false;

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.05f , GrabLayer);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}