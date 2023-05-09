using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform objectToFollow;
    public float followSpeed = 5f;
    public float followDistance = 3f;
    private SpriteRenderer sr;
    [SerializeField] private bool facingRight = true;
    private Vector3 Diff;
    
    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 heading = objectToFollow.transform.position - transform.position;
        heading.y = 0;
        var distance = heading.magnitude;
        var direction = heading.normalized;
        
        if (distance>0.3f)
        {
            transform.Translate(direction * followSpeed * Time.deltaTime);
        }

        if (objectToFollow.position.x < transform.position.x)
        {
            sr.flipX = true;
        }
        else if (objectToFollow.position.x > transform.position.x)
        {
            sr.flipX = false;
        }
    }
}