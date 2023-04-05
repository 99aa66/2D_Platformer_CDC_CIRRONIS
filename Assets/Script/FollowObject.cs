using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow;
    public float followSpeed = 5f;

    private Vector3 Diff;
    private bool facingRight = true; 

    void Start()
    {
        Diff = transform.position - objectToFollow.position;
    }

    void LateUpdate()
    {
        Vector3 targetPosition = objectToFollow.position + Diff;

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

        if (transform.position.x < objectToFollow.position.x && !facingRight)
        {
            Flip();
        }
        else if (transform.position.x > objectToFollow.position.x && facingRight)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

