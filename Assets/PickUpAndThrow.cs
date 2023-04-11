using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpAndThrow : MonoBehaviour
{
    public float throwForce = 10f;
    private bool isPickedUp = false; 
    private Rigidbody2D rb2d;
    public Transform grabCheck;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isPickedUp)
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
        transform.parent = grabCheck.transform; 
        transform.localPosition = new Vector3(0.5f, 0.5f, 1f); 
        isPickedUp = true;
    }

    void Throw()
    {
        rb2d.isKinematic = false;
        transform.parent = null;
        
        rb2d.AddForce(grabCheck.transform.forward * throwForce, ForceMode2D.Impulse);
        rb2d.AddForce(grabCheck.transform.up * throwForce, ForceMode2D.Impulse);
        isPickedUp = false;
    }
}