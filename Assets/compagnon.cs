using UnityEngine;

public class Companion : MonoBehaviour
{
    public Transform player; // Le transform du joueur
    public float followDistance = 3f; // La distance à laquelle le compagnon suit le joueur
    public float followSpeed = 5f; // La vitesse de suivi

    private Vector3 offset; 

    void Start()
    {
        offset = transform.position - player.position;
    }

    void FixedUpdate()
    {
        // On calcule la position à laquelle le compagnon doit se rendre
        Vector3 targetPosition = player.position + offset;

        // On déplace le compagnon vers cette position avec une vitesse donnée
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.fixedDeltaTime);

        // On oriente le compagnon dans la bonne direction si le joueur est derrière lui
        if (player.position.x < transform.position.x && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (player.position.x > transform.position.x && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        // On maintient une certaine distance entre le compagnon et le joueur
        float distance = Vector2.Distance(transform.position, player.position);
        if (distance > followDistance)
        {
            offset = (offset / distance) * followDistance;
        }
    }
}