using UnityEngine;

public class Companion : MonoBehaviour
{
    public Transform player;
    public float followDistance = 3f; 
    public float followSpeed = 5f; 

    private Vector3 offset; 

    void Start()
    {
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = player.position + offset;

        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.fixedDeltaTime);

        if (player.position.x < transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (player.position.x > transform.position.x && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > followDistance)
        {
            offset = (offset / distance) * followDistance;
        }
    }
}