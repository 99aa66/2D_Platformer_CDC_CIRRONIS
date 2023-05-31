using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject player;
    [SerializeField]  private float speed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Tartine_Player");
        rb = GetComponent<Rigidbody2D>();
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        rb.velocity = new Vector2(direction.x * speed,0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
       

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") == true)
        {
            collision.gameObject.GetComponent<Player_Health>().TakeDamage(20);
            Destroy(gameObject);
        }
    }
}
