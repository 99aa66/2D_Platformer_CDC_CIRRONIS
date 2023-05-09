using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndThrow : MonoBehaviour
{
    public float throwForce = 10f;
    private bool isPickedUp = false; 
    private Rigidbody2D rb2d;
    public Transform grabCheck;
    public LayerMask GrabLayer; // couche du sol
    private bool isPick;
    private FollowObject Follow;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isPick = Physics2D.OverlapCircle(grabCheck.position, 0.2f, GrabLayer);
        if (Input.GetKeyDown(KeyCode.G) && !isPickedUp)
        {
            PickUp();
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0) && isPickedUp)
        {
            Throw(); 
        }
    }

    void PickUp()
    {
        rb2d.isKinematic = true;
        //rb2d.gravityScale = 0;
        Follow = gameObject.GetComponent<FollowObject>();
        Follow.enabled = false;
        transform.parent = grabCheck.transform; 
        transform.localPosition = new Vector2(0.5f, 0.5f); 
        isPickedUp = true;

    }

    void Throw()
    {
        rb2d.isKinematic = false;
        rb2d.AddForce(grabCheck.transform.forward * throwForce, ForceMode2D.Impulse);
        //rb2d.AddForce(grabCheck.transform.up * throwForce, ForceMode2D.Impulse);
        isPickedUp = false;
    }


}