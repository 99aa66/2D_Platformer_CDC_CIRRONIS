using UnityEngine;

public class FollowObject : MonoBehaviour
{
    public Transform objectToFollow;
    public float followSpeed = 5f;
    public float followDistance = 3f;
    private SpriteRenderer sr;
    [SerializeField] private bool facingRight = true;
    private Vector3 Diff;

    void Start()
    {
        transform.position = objectToFollow.position;
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Diff = objectToFollow.position - transform.position;
        float distance = Vector2.Distance(transform.position, objectToFollow.position);
        if (distance > followDistance)
        {
            Vector3 targetPosition = objectToFollow.position + Diff;

            transform.position = Vector2.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);


            if (objectToFollow.position.x < transform.position.x && !facingRight)
            {
                Flip();
            }
            else if (objectToFollow.position.x > transform.position.x && facingRight)
            {
                Flip();
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}

