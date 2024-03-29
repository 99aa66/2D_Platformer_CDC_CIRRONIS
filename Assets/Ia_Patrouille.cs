using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ia_Patrouille : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Transform[] waypoints;

    public int damageOnCollision = 5; //au moment de la collision il y a d�g�ts -2

    [SerializeField] SpriteRenderer graphics;
    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        //Commencer par le premier waypoints de la liste
        target = waypoints[0]; 
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        //Si l'ennemi est quasiment arriv� � sa destination
        if(Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
            graphics.flipX = !graphics.flipX;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            collision.gameObject.GetComponent<Player_Health>().TakeDamage(damageOnCollision);

        }
    }
}
